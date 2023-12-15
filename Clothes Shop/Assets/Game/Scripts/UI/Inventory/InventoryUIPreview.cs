using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

public class InventoryUIPreview {
    private VisualElement element;
    private VisualElement hatElement;
    private VisualElement hairElement;
    private VisualElement clothesElement;
    private VisualElement underwearElement;

    public InventoryUIPreview(VisualElement element) {
        Assert.IsNotNull(element, "VisualElement can't be null.");
        this.element = element;

        hatElement = element.Q<VisualElement>("Hat");
        hairElement = element.Q<VisualElement>("Hair");
        clothesElement = element.Q<VisualElement>("Clothes");
        underwearElement = element.Q<VisualElement>("Underwear");
        Assert.IsNotNull(hatElement, "Missing VisualElement 'Hat'.");
        Assert.IsNotNull(hairElement, "Missing VisualElement 'Hair'.");
        Assert.IsNotNull(clothesElement, "Missing VisualElement 'Clothes'.");
        Assert.IsNotNull(underwearElement, "Missing VisualElement 'Underwear'.");
    }

    public void Refresh(Outfit outfit) {
        Assert.IsNotNull(outfit, "Missing required Outfit.");

        UpdatePartElement(hatElement, outfit.hat);
        UpdatePartElement(hairElement, outfit.hair);
        UpdatePartElement(clothesElement, outfit.clothes);
        UpdatePartElement(underwearElement, outfit.underwear);
    }

    private void UpdatePartElement(VisualElement element, ItemData item) {
        if (item == null || item.icon == null || item.sprite == null) {
            element.style.display = DisplayStyle.None;
            return;
        }

        element.style.display = DisplayStyle.Flex;
        element.style.backgroundImage = new StyleBackground(item.sprite);
    }

    private StyleBackground CreateBackgroundOrNull(ItemData item) {
        if (item == null || item.icon == null) {
            return new StyleBackground((Texture2D) null);
        }

        return new StyleBackground(item.icon);
    }
}
