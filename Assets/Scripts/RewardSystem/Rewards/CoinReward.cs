using UnityEngine;

public class CoinReward : IReward
{
    public Rarity ChestRarity { get; set; }
    public RewardUISO RewardUISO { get; set ; }

    public void Claim()
    {
        const int ammountToIncrese = 100;
        CoinService.OnChangeCoins?.Invoke(ammountToIncrese);
        RewardUIService.OnClaimSomething?.Invoke(RewardType.Coin100);
    }

    public CoinReward(Rarity chestRarity)
    {
        ChestRarity = chestRarity;
    }
}
