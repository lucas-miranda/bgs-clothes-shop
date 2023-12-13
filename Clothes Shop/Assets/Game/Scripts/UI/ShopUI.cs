using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Assertions;

[RequireComponent(typeof(UIDocument))]
public class ShopUI : MonoBehaviour {
    private const string PriceFormat = "${0}";
    private UIDocument uiDocument;
    private VisualElement itemGridElement;

    void Start() {
        uiDocument = GetComponent<UIDocument>();
        itemGridElement = uiDocument.rootVisualElement.Q<VisualElement>("ItemGrid");
    }

    /// Load every shop entry.
    public void Load(ShopData shopData) {
        Assert.IsNotNull(shopData, "Provided ShopData can't be null.");
        Assert.IsNotNull(shopData.items, "Provided ShopData's items can't be null.");

        int i = 0;

        // register every item on a cell
        for (; i < shopData.items.Length && i < itemGridElement.childCount; i++) {
            VisualElement childElement = itemGridElement[i];
            LoadEntry(childElement, shopData.items[i]);
        }

        // clear remaining cells
        for (; i < itemGridElement.childCount; i++) {
            VisualElement childElement = itemGridElement[i];
            ClearEntry(childElement);
        }
    }

    public void Show() {
        uiDocument.enabled = true;
    }

    public void Hide() {
        uiDocument.enabled = false;
    }

    private void LoadEntry(VisualElement shopItemElement, ShopEntryData entryData) {
        Label displayLabel = shopItemElement.Q<Label>("Display");
        Label priceLabel = shopItemElement.Q<Label>("Price");
        displayLabel.style.backgroundImage = new StyleBackground(entryData.item.icon);
        priceLabel.text = string.Format(PriceFormat, entryData.price);
    }

    private void ClearEntry(VisualElement shopItemElement) {
        Label displayLabel = shopItemElement.Q<Label>("Display");
        Label priceLabel = shopItemElement.Q<Label>("Price");
        displayLabel.style.backgroundImage = null;
        priceLabel.visible = false;
    }
}
