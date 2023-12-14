using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

public class InventoryUIEquipKind {
    public event System.Action<InventoryUIItem> OnItemClicked;

    private VisualElement element;
    private ScrollView contentsScrollView;
    private VisualTreeAsset itemDocument;
    private List<InventoryUIItem> items = new List<InventoryUIItem>();

    public InventoryUIEquipKind(VisualElement element, VisualTreeAsset itemDocument) {
        Assert.IsNotNull(element, "VisualElement can't be null.");
        Assert.IsNotNull(itemDocument, "ItemDocument can't be null.");
        this.element = element;
        this.itemDocument = itemDocument;
        contentsScrollView = element.Q<ScrollView>("Contents");
        Assert.IsNotNull(contentsScrollView, "Contents ScrollView was not found.");
    }

    public InventoryUIItem Find(ItemData item) {
        foreach (InventoryUIItem uiItem in items) {
            if (uiItem.item == item) {
                return uiItem;
            }
        }

        return null;
    }

    public void Register(ItemData item) {
        TemplateContainer templateContainer = itemDocument.Instantiate();
        contentsScrollView.contentContainer.Add(templateContainer);

        VisualElement itemElement = contentsScrollView.contentContainer[contentsScrollView.contentContainer.childCount - 1];
        InventoryUIItem uiItem = new InventoryUIItem(itemElement, item);
        items.Add(uiItem);
        uiItem.OnClicked += ItemClicked;
    }

    public void Clear() {
        contentsScrollView.contentContainer.Clear();

        foreach (InventoryUIItem item in items) {
            item.Reset();
        }

        items.Clear();
    }

    private void ItemClicked(InventoryUIItem uiItem) {
        OnItemClicked?.Invoke(uiItem);
    }
}
