using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Assertions;

public class InventoryUI : BaseUI {
    public VisualTreeAsset itemDocument;

    private Dictionary<EquipKind, InventoryUIEquipKind> selectors = new Dictionary<EquipKind, InventoryUIEquipKind>();
    private InventoryUIPreview preview;
    private Outfit outfit;

    protected override void Awake() {
        base.Awake();

        // preview
        VisualElement previewElement = mainElement.Q<VisualElement>("Preview");
        Assert.IsNotNull(previewElement, "Missing VisualElement 'Preview'.");
        preview = new InventoryUIPreview(previewElement);

        // item selectors
        VisualElement itemSelectors = mainElement.Q<VisualElement>("ItemSelectors");

        foreach (VisualElement selectorElement in itemSelectors.Children()) {
            bool found = System.Enum.TryParse<EquipKind>(selectorElement.name, out EquipKind kind);
            Assert.IsTrue(found, $"Invalid selector name '{selectorElement.name}', it must be a EquipKind enum name.");

            InventoryUIEquipKind selector = new InventoryUIEquipKind(selectorElement, itemDocument);
            selector.OnItemClicked += ItemClicked;
            selectors.Add(kind, selector);
        }

        mainElement.style.display = DisplayStyle.None;
    }

    public void Refresh() {
        Reset();

        foreach (ItemData item in Inventory.Instance.items) {
            selectors[item.Kind].Register(item);
        }

        if (GameUtil.TryGetPlayer(out GameObject player)
         && player.TryGetComponent<Outfit>(out Outfit playerOutfit)
        ) {
            outfit = playerOutfit;
            preview.Refresh(playerOutfit);
            SelectActiveItems();
        } else {
            outfit = null;
        }
    }

    public void Reset() {
        foreach (InventoryUIEquipKind selector in selectors.Values) {
            selector.Clear();
        }
    }

    protected override void Opened() {
        Refresh();
    }

    protected override void Closed() {
        outfit = null;
    }

    private void ItemClicked(InventoryUIItem uiItem) {
        if (outfit == null) {
            return;
        }

        bool equipped;

        if (outfit.IsItemEquipped(uiItem.item)) {
            if (outfit.Unequip(uiItem.item.Kind)) {
                equipped = false;
            } else {
                Assert.IsTrue(false, "Failed to unequip item.");
                equipped = true;
            }
        } else {
            if (outfit.Equip(uiItem.item)) {
                equipped = true;
            } else {
                Assert.IsTrue(false, "Failed to equip item.");
                equipped = false;
            }
        }

        uiItem.SetEquippedState(equipped);

        // update preview
        preview.Refresh(outfit);
    }

    private void SelectActiveItems() {
        foreach (EquipKind equipKind in System.Enum.GetValues(typeof(EquipKind))) {
            ItemData equippedItem = outfit.GetEquippedItem(equipKind);

            if (equippedItem == null) {
                continue;
            }

            InventoryUIItem uiItem = selectors[equipKind].Find(equippedItem);
            Assert.IsNotNull(uiItem, $"Item was not registered at {equipKind} selector UI.");
            uiItem.SetEquippedState(true);
        }
    }
}
