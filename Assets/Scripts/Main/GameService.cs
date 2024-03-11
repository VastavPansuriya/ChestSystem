using Singleton;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameService : GenericMonoSingleton<GameService>
{
    [Header(nameof(ChestService))]
    [SerializeField] private Button spawnChestButton;
    [SerializeField] private Animator notEmptyPopup;
    [SerializeField] private Animator notEnoughAmountPopup;
    [SerializeField] private List<ChestUI> allChest;

    [Header(nameof(CoinService))]
    [SerializeField] private TMP_Text coinText;

    [Header(nameof(GemService))]
    [SerializeField] private TMP_Text gemsText;

    [Header(nameof(RewardUIService))]
    [SerializeField] private Image rewardImage;
    [SerializeField] private TMP_Text rewardInfoText;
    [SerializeField] private RewardUISOList rewardUISOList;
    [SerializeField] private Animator rewardPopup;

    public ChestService ChestSR { get; private set; }
    public CoinService CoinSR { get; private set; }
    public GemService GemSR { get; private set; }
    public RewardUIService RewardUISR { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        InitService();
    }

    private void InitService()
    {
        ChestSR = new ChestService(new ChestService.NeededDataChestService()
        {
            spawnButton = spawnChestButton,
            notemptyPopup = notEmptyPopup,
            notEnoughAmountPopup = notEnoughAmountPopup,
            allChest = new List<ChestUI>(allChest)
        });

        CoinSR = new CoinService(coinText);
        GemSR = new GemService(gemsText);
        RewardUISR = new RewardUIService(rewardImage, rewardInfoText, rewardUISOList,rewardPopup);
    }
}
