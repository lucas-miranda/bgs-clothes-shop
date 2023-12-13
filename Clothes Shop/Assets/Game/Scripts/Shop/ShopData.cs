using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Game Data/Shop/Listing")]
public class ShopData : ScriptableObject {
    public ShopEntryData[] items;
}
