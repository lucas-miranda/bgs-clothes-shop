using UnityEngine;

public abstract class ItemData : ScriptableObject {
    public Sprite icon;
    public RuntimeAnimatorController animatorController;

    public abstract EquipKind Kind { get; }
}
