using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Game Data/Items/Hat")]
public class HatItemData : ItemData {
    public override EquipKind Kind { get { return EquipKind.Hat; } }
}
