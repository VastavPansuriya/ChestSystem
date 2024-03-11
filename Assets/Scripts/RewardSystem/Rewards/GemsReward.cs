using UnityEngine;

public class GemsReward : IReward
{
    public Rarity ChestRarity { get; set; }
    public RewardUISO RewardUISO { get; set; }

    public void Claim()
    {
        const int ammountToIncrese = 5;
        GemService.OnChangeGems?.Invoke(ammountToIncrese);
        RewardUIService.OnClaimSomething?.Invoke(RewardType.Gems5);
    }

    public GemsReward(Rarity chestRarity)
    {
        ChestRarity = chestRarity;
    }
}

public class PlayerPower : IReward
{
    public Rarity ChestRarity { get; set; }
    public RewardUISO RewardUISO { get; set; }

    public void Claim()
    {
        throw new System.NotImplementedException();
    }

    public PlayerPower(Rarity rarity)
    {
        ChestRarity = rarity;
    }
}
