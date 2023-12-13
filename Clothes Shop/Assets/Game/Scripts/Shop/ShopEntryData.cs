using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Game Data/Shop/Entry")]
public class ShopEntryData : ScriptableObject {
    public ItemData item;
    public int price;
}
