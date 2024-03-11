using System.Collections.Generic;
using UnityEngine;

public class ChestController
{
    #region Fields

    private ChestDataListSO chestDataListSO;
    private List<ChestDataSO> allChest;

    private ChestUI chestUI;
    private ChestDataSO currentChestDataSo;

    private ChestStateMachine stateMachine;

    private IReward reward;


    private float remainingTime = 0;

    #endregion


    #region InitChectController

    public ChestController(ChestUI chestUI, ChestDataListSO chestDataListSO)
    {
        this.chestDataListSO = chestDataListSO;
        this.chestUI = chestUI;

        allChest = new List<ChestDataSO>(this.chestDataListSO.data);

        CreateStateMachine();
        stateMachine.ChangeState(ChestState.Empty);
    }

    private void CreateStateMachine() => stateMachine = new ChestStateMachine(this);

    public void StartActivation(IReward reward)
    {
        this.reward = reward;
        SetChest(reward.ChestRarity);
        OnLockedState();
    }

    private void SetChest(Rarity rarity)
    {
        Debug.Log(allChest.Count + "," + rarity);

        currentChestDataSo = allChest.Find(item => item.chestRarity.Equals(rarity));
        chestUI.SetImage(currentChestDataSo.chestSprite);
    }

    #endregion


    #region  SetPublicStuff

    public void SetInfo(string val)
    {
        chestUI.SetInfo(val);
    }

    public void SetPrice(float time)
    {
        chestUI.SetPrice(CalculateUnlockPrice(time).ToString());
    }

    public void SetEmpty()
    {
        chestUI.SetEmpty();
        chestUI.SetInfo("");
    }

    public void SetChestVisualActive()
    {
        chestUI.SetActive();
    }

    public void PurchaseButtonToggle(bool v)
    {
        chestUI.PurchaseButtonToggle(v);
    }

    #endregion


    #region ManageState
    private void OnLockedState()
    {
        stateMachine.ChangeState(ChestState.Locked);
    }

    private void OnProgressStart()
    {
        stateMachine.ChangeState(ChestState.Progress);
    }

    public void OnProgressComplete()
    {
        stateMachine.ChangeState(ChestState.Open);
    }

    private void OnOpenChestState()
    {
        stateMachine.ChangeState(ChestState.Empty);
    }
    #endregion


    #region DoSomthing

    public void OnChestClick()
    {
        switch (stateMachine.GetCurrState())
        {
            case ChestState.Empty:
                break;
            case ChestState.Locked:
                if (GameService.Instance.ChestSR.CanStartProgress())
                {
                    OnProgressStart();
                }
                break;
            case ChestState.Progress:
                break;
            case ChestState.Open:

                reward.Claim();
                OnOpenChestState();
                break;
            default:
                break;
        }
    }

    public void OnPurchse()
    {
        int price = 0;
        switch (stateMachine.GetCurrState())
        {
            case ChestState.Locked:
                price = CalculateUnlockPrice(GetTotalTime());
                break;
            case ChestState.Progress:
                price = CalculateUnlockPrice(remainingTime);
                break;
        }

        if (!(bool)(GemService.OnChangeGems?.Invoke(-price)))
        {
            GameService.Instance.ChestSR.PopupNoEnoughCoin();
        }
        else
        {
            OnProgressComplete();
        }

    }

    public void StateUpdate()
    {
        stateMachine.Update();
    }

    public void SetReaminingTime(float v) => remainingTime = v;

    private int CalculateUnlockPrice(float remainingTime)
    {
        int price = Mathf.CeilToInt(remainingTime / 60); // 600 seconds = 10 minutes
        return price;
    }

    #endregion


    #region GetData
    public float GetTotalTime() => currentChestDataSo.time;
    public ChestDataSO GetChestDataSO()
    {
        return currentChestDataSo;
    }
    public ChestState GetChestState()
    {
        return stateMachine.GetCurrState();
    }

    #endregion
}