public interface IReward
{
    public Rarity ChestRarity { get; set; }
    public RewardUISO RewardUISO { get; set; }
    public void Claim();
}
