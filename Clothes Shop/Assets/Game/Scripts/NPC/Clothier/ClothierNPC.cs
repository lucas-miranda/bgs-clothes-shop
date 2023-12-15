using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Outfit))]
public class ClothierNPC : MonoBehaviour {
    public ShopUI shopUI;
    public ShopData shopData;

    private List<ShopEntryData> availableItems;
    private PlayerInteract interactor;

    void Start() {
        Assert.IsNotNull(shopUI, "Missing ShopUI.");
        Assert.IsNotNull(shopData, "Missing ShopData.");

        shopUI.OnEntryClicked += ShopEntryClicked;
        availableItems = new List<ShopEntryData>(shopData.items);

        Outfit outfit = GetComponent<Outfit>();
        outfit.ChangeState(false, 0, -1, true);
    }

    void Update() {
    }

    public void Interacted(PlayerInteract interactor) {
        this.interactor = interactor;
        shopUI.Load(availableItems);
        shopUI.Open();
        shopUI.OnClosed += ShopUIClosed;
    }

    private void ShopEntryClicked(ShopEntryUI entry) {
        if (entry.IsEmpty) {
            return;
        }

        // buy item, if player has needed money amount
        Inventory inventory = Inventory.Instance;

        if (!inventory.SpendMoney(entry.data.price)) {
            // player doesn't have the money amount
            return;
        }

        availableItems.Remove(entry.data);
        inventory.AddItem(entry.data.item);
        entry.Clear();

        // just close after one purchase
        shopUI.Close();
    }

    private void ShopUIClosed() {
        shopUI.OnClosed -= ShopUIClosed;
        interactor = null;
    }
}
