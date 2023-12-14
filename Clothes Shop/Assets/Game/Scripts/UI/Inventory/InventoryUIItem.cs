using UnityEngine.Assertions;
using UnityEngine.UIElements;

public class InventoryUIItem {
    public const string EquippedClassName = "Equipped",
                        UnequippedClassName = "Unequipped";

    public event System.Action<InventoryUIItem> OnClicked;

    public ItemData item;
    public bool isEquipped;

    private VisualElement element;
    private Button button;

    public InventoryUIItem(VisualElement element, ItemData item) {
        Assert.IsNotNull(element, "VisualElement can't be null.");
        this.element = element;
        Assert.IsNotNull(item, "ItemData can't be null.");
        this.item = item;

        // change icon to match item
        VisualElement itemIconElement = element.Q<VisualElement>("ItemIcon");
        itemIconElement.style.backgroundImage = new StyleBackground(item.icon);

        // hook into button's clicked event
        if (element is Button) {
            UnityEngine.Debug.Log("is button!");
        } else {
            UnityEngine.Debug.Log("not is button!");
        }

        button = element.Q<Button>("Main");
        Assert.IsNotNull(button, "Button 'Main' was not found.");
        button.clicked += Clicked;
    }

    public void SetEquippedState(bool equipped) {
        if (equipped == isEquipped) {
            return;
        }

        isEquipped = equipped;
        if (isEquipped) {
            button.RemoveFromClassList(UnequippedClassName);
            button.AddToClassList(EquippedClassName);
        } else {
            button.RemoveFromClassList(EquippedClassName);
            button.AddToClassList(UnequippedClassName);
        }
    }

    public void Reset() {
        OnClicked = null;
        item = null;
        element = null;
        button = null;
    }

    private void Clicked() {
        OnClicked?.Invoke(this);
    }
}
