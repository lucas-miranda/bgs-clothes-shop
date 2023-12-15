using UnityEngine;

public abstract class ItemData : ScriptableObject {
    public Sprite icon;
    public Sprite sprite;
    public RuntimeAnimatorController animatorController;

    public abstract EquipKind Kind { get; }
}
