using UnityEngine.UIElements;
using UnityEngine.Assertions;

public class ShopEntryUI {
    public event System.Action<ShopEntryUI> OnClicked;

    /// Shop item root element.
    public VisualElement element;

    /// Associated data with this entry.
    public ShopEntryData data;

    private Label displayLabel;
    private Label priceLabel;

    public ShopEntryUI(VisualElement element) {
        Assert.IsNotNull(element, "Provided VisualElement can't be null.");
        this.element = element;
        displayLabel = element.Q<Label>("Display");
        priceLabel = element.Q<Label>("Price");

        Button button = element.Q<Button>("Item");
        button.clicked += Clicked;
    }

    public bool IsEmpty { get => data == null; }

    public void Load(ShopEntryData entryData) {
        Assert.IsNotNull(entryData, "Provided ShopEntryData can't be null.");
        Assert.IsNotNull(entryData.item, "Provided ShopEntryData's item icon can't be null.");

        data = entryData;
        displayLabel.style.backgroundImage = new StyleBackground(entryData.item.icon);
        priceLabel.text = string.Format(ShopUI.PriceFormat, entryData.price);
    }

    public void Clear() {
        data = null;
        displayLabel.style.backgroundImage = null;
        priceLabel.visible = false;
    }

    private void Clicked() {
        OnClicked?.Invoke(this);
    }
}
