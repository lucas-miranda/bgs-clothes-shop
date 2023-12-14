using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.Assertions;

public class ShopUI : BaseUI {
    public event System.Action<ShopEntryUI> OnEntryClicked;

    public const string PriceFormat = "${0}";

    private VisualElement itemGridElement;
    private ShopEntryUI[] entries;

    protected override void Awake() {
        base.Awake();

        itemGridElement = mainElement.Q<VisualElement>("ItemGrid");
        Assert.IsNotNull(itemGridElement, "ItemGrid VisualElement not found.");

        // create an wrapper for every shop entry
        // it'll handle that entry state
        // and make easier to handle events later
        entries = new ShopEntryUI[itemGridElement.childCount];
        int i = 0;
        foreach (VisualElement childElement in itemGridElement.Children()) {
            ShopEntryUI entry = new ShopEntryUI(childElement);
            entries[i] = entry;
            entry.OnClicked += EntryClicked;
            i += 1;
        }

        mainElement.style.display = DisplayStyle.None;
    }

    void Start() {
    }

    /// Load every shop entry.
    public void Load(IList<ShopEntryData> items) {
        Assert.IsNotNull(items, "Provided items can't be null.");

        int i = 0;

        // register every item on a cell
        for (; i < items.Count && i < entries.Length; i++) {
            ShopEntryUI entry = entries[i];
            entry.Load(items[i]);
        }

        // clear remaining cells
        for (; i < itemGridElement.childCount; i++) {
            ShopEntryUI entry = entries[i];
            entry.Clear();
        }
    }

    protected override void Opened() {
    }

    protected override void Closed() {
    }

    private void EntryClicked(ShopEntryUI entry) {
        OnEntryClicked?.Invoke(entry);
    }
}
