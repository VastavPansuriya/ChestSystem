using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ChestService;
using VRandom = UnityEngine.Random;


public class ChestService
{    
    private IReward[] allReward;

    [Serializable]
    public class NeededDataChestService
    {
        public Button spawnButton;
        public Animator notemptyPopup;
        public Animator notEnoughAmountPopup;
        public List<ChestUI> allChest;
    }

    private const string POPUP = "Pop";

    private NeededDataChestService neededDataChestService;

    public ChestService(NeededDataChestService neededDataChestService)
    {
        this.neededDataChestService = neededDataChestService;

        allReward =
            new IReward[]
            { new CoinReward(Rarity.Common)
            , new GemsReward(Rarity.Rere)};

        InitListeners();

    }

    private void InitListeners()
    {
        neededDataChestService.spawnButton.onClick.AddListener(() =>
        {
            if (!TryActiveChest(out ChestUI chest))
            {
                ShowPopup();
            }
            else
            {
                IReward newChestReward = allReward[VRandom.Range(0, allReward.Length)];
                ChestController chestController = chest.GetController();
                chestController.StartActivation(newChestReward);
            }
        });
    }

    private void ShowPopup()
    {
        neededDataChestService.notemptyPopup.SetTrigger(POPUP);
    }

    private bool TryActiveChest(out ChestUI chestUI)
    {
        foreach (ChestUI chest in neededDataChestService.allChest)
        {
            if (chest.IsChestEmpty())
            {
                chestUI = chest;
                return true;
            }
        }
        chestUI = null;
        return false;
    }

    public bool CanStartProgress()
    {
        foreach (ChestUI item in neededDataChestService.allChest)
        {
            if (item.GetController().GetChestState() == ChestState.Progress)
            {
                return false;
            }
        }
        return true;
    }

    public void PopupNoEnoughCoin()
    {
        neededDataChestService.notEnoughAmountPopup.SetTrigger(POPUP);
    }
}
