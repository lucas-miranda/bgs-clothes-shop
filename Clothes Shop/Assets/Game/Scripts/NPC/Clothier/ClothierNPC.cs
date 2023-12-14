using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ClothierNPC : MonoBehaviour {
    public ShopUI shopUI;
    public ShopData shopData;

    private List<ShopEntryData> availableItems;

    void Start() {
        Assert.IsNotNull(shopUI, "Missing ShopUI.");
        Assert.IsNotNull(shopData, "Missing ShopData.");

        shopUI.OnEntryClicked += ShopEntryClicked;
        availableItems = new List<ShopEntryData>(shopData.items);
    }

    void Update() {
    }

    public void Interacted() {
        shopUI.Load(availableItems);
        shopUI.Show();
    }

    private void ShopEntryClicked(ShopEntryUI entry) {
        if (entry.IsEmpty) {
            return;
        }

        // buy item, if player has needed money amount
        Inventory inventory = Inventory.Instance;
        if (inventory.SpendMoney(entry.data.price)) {
            availableItems.Remove(entry.data);
            inventory.AddItem(entry.data.item);
            entry.Clear();
        }
    }
}
