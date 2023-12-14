using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Game Data/Items/Hair")]
public class HairItemData : ItemData {
    public override EquipKind Kind { get { return EquipKind.Hair; } }
}
