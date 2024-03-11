using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardUIService
{

    public static Action<RewardType> OnClaimSomething;

    private Image rewardImage;
    private TMP_Text infoText;

    private RewardUISOList rewardUISOList;
    private Animator rewardPopup;

    private const string POPUP = "Pop";

    public RewardUIService(Image rewardImage, TMP_Text infoText, RewardUISOList rewardUISOList,Animator rewardPopup)
    {
        this.infoText = infoText;
        this.rewardImage = rewardImage;
        this.rewardUISOList = rewardUISOList;
        this.rewardPopup = rewardPopup;

        OnClaimSomething += RewardUIManager_OnClaimSomething;
    }

    private void RewardUIManager_OnClaimSomething(RewardType obj)
    {
        RewardUISO rewardUISO = rewardUISOList.GetRewardUISOData(obj);

        rewardImage.sprite = rewardUISO.rewardSprite;
        infoText.text = rewardUISO.rewardInfo;

        rewardPopup.SetTrigger(POPUP);
    }

    ~RewardUIService()
    {
        OnClaimSomething -= RewardUIManager_OnClaimSomething;
    }
}