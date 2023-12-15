using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Outfit : MonoBehaviour {
    public HatItemData hat;
    public HairItemData hair;
    public ClothesItemData clothes;
    public UnderwearItemData underwear;

    /// <summary>
    /// Can auto-equip item when received it, if there is none at their slot.
    /// </summary>
    public bool canAutoEquip = true;

    private Dictionary<EquipKind, Part> parts = new Dictionary<EquipKind, Part>();
    private Animator[] animators;

    void Awake() {
        animators = GetComponentsInChildren<Animator>();
        InitializeParts();
    }

    void Start() {
    }

    void Update() {
    }

    void OnEnable() {
    }

    void OnValidate() {
        InitializeParts();

        // NOTE  this section could be better future-proof
        //       if we use an attribute at each field
        //       to describe which EquipKind it is

        if (parts.TryGetValue(EquipKind.Hat, out Part hatPart)) {
            hatPart.Set(hat);
        }

        if (parts.TryGetValue(EquipKind.Hair, out Part hairPart)) {
            hairPart.Set(hair);
        }

        if (parts.TryGetValue(EquipKind.Clothes, out Part clothesPart)) {
            clothesPart.Set(clothes);
        }

        if (parts.TryGetValue(EquipKind.Underwear, out Part underwearPart)) {
            underwearPart.Set(underwear);
        }
    }

    public void ReceivedItem(ItemData item) {
        if (canAutoEquip) {
            // when buying an item auto-equip if there is nothing at their slot

            if (GetEquippedItem(item.Kind) == null) {
                Equip(item);
            }
        }
    }

    public bool IsItemEquipped(ItemData item) {
        foreach (EquipKind equipKind in System.Enum.GetValues(typeof(EquipKind))) {
            if (GetEquippedItem(equipKind) == item) {
                return true;
            }
        }

        return false;
    }

    public ItemData GetEquippedItem(EquipKind kind) {
        switch (kind) {
            case EquipKind.Hat:
                return hat;
            case EquipKind.Hair:
                return hair;
            case EquipKind.Clothes:
                return clothes;
            case EquipKind.Underwear:
                return underwear;
            default:
                break;
        }

        return null;
    }

    public bool CanEquip(ItemData itemData) {
        if (itemData == null || !parts.ContainsKey(itemData.Kind)) {
            // there is no part registered for provided EquipKind
            return false;
        }

        switch (itemData.Kind) {
            case EquipKind.Hat:
                return itemData is HatItemData;
            case EquipKind.Hair:
                return itemData is HairItemData;
            case EquipKind.Clothes:
                return itemData is ClothesItemData;
            case EquipKind.Underwear:
                return itemData is UnderwearItemData;
            default:
                break;
        }

        return false;
    }

    public bool Equip(ItemData itemData) {
        if (!CanEquip(itemData)) {
            return false;
        }

        Part part = parts[itemData.Kind];
        part.Set(itemData);

        switch (itemData.Kind) {
            case EquipKind.Hat:
                hat = (HatItemData) itemData;
                break;
            case EquipKind.Hair:
                hair = (HairItemData) itemData;
                break;
            case EquipKind.Clothes:
                clothes = (ClothesItemData) itemData;
                break;
            case EquipKind.Underwear:
                underwear = (UnderwearItemData) itemData;
                break;
            default:
                break;
        }

        return true;
    }

    public bool Unequip(EquipKind kind) {
        if (!parts.TryGetValue(kind, out Part part)) {
            // there is no part registered for provided EquipKind
            return false;
        }

        part.Set(null);

        switch (kind) {
            case EquipKind.Hat:
                hat = null;
                break;
            case EquipKind.Hair:
                hair = null;
                break;
            case EquipKind.Clothes:
                clothes = null;
                break;
            case EquipKind.Underwear:
                underwear = null;
                break;
            default:
                break;
        }

        return true;
    }

    public void ChangeState(bool isWalking, int faceHDirection, int faceVDirection, bool force = false) {
        // update each body part animator
        foreach (Animator animator in animators) {
            if (animator.runtimeAnimatorController == null) {
                // skip empty parts
                continue;
            }

            animator.SetBool("Walking", isWalking);
            if (isWalking || force) {
                // only change face direction when moving
                animator.SetFloat("FaceHorizontal", faceHDirection);
                animator.SetFloat("FaceVertical", faceVDirection);
            }
        }
    }

    private void InitializeParts() {
        parts.Clear();

        foreach (Transform child in transform) {
            if (System.Enum.TryParse<EquipKind>(child.gameObject.name, true, out EquipKind kind)) {
                parts.Add(kind, new Part(child.gameObject));
            }
        }
    }

    private class Part {
        public Animator animator;
        public SpriteRenderer renderer;

        public Part(GameObject part) {
            animator = part.GetComponent<Animator>();
            Assert.IsNotNull(animator, "Missing Animator component.");
            renderer = part.GetComponent<SpriteRenderer>();
            Assert.IsNotNull(renderer, "Missing SpriteRenderer component.");
        }

        public void Set(ItemData data) {
            if (data == null) {
                animator.runtimeAnimatorController = null;
                renderer.sprite = null;
                return;
            }

            animator.runtimeAnimatorController = data.animatorController;

#if UNITY_EDITOR
            // TODO  use character direction at editor to choose appropriated direction
            renderer.sprite = data.sprite;
#else
            // nothing to be done
            // animator will handle sprite changing for us
#endif
        }
    }
}
