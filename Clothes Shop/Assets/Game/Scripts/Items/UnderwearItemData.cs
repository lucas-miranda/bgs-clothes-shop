using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Game Data/Items/Underwear")]
public class UnderwearItemData : ItemData {
    public override EquipKind Kind { get { return EquipKind.Underwear; } }
}
