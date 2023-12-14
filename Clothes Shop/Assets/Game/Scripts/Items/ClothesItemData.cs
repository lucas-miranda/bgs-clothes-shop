using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Game Data/Items/Clothes")]
public class ClothesItemData : ItemData {
    public override EquipKind Kind { get { return EquipKind.Clothes; } }
}
