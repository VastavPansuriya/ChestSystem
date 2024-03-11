using UnityEngine;

[CreateAssetMenu()] 
//model
public class ChestDataSO : ScriptableObject
{
    public Rarity chestRarity;

    [Space()]
    public float time;
    public Sprite chestSprite;
}
