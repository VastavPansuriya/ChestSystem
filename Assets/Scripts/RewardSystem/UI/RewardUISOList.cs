using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RewardUISOList : ScriptableObject
{
    public List<RewardUISO> rewardUISOs = new List<RewardUISO>();

    private Dictionary<RewardType, RewardUISO> rewardUIData;

    public RewardUISO GetRewardUISOData(RewardType rewardType)
    {
        if (rewardUIData == null)
        {
            rewardUIData = new Dictionary<RewardType, RewardUISO>();
            foreach (RewardUISO item in rewardUISOs)
            {
                rewardUIData.Add(item.rewardType, item);
            }
        }

        rewardUIData.TryGetValue(rewardType,out RewardUISO rewardUISO);
        return rewardUISO;
    }
}
