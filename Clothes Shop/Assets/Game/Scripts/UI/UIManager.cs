using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public InventoryUI inventory;
    public ShopUI shop;

    private List<BaseUI> uis = new List<BaseUI>();

    void Awake() {
        foreach (Transform child in transform) {
            if (this.inventory == null && child.TryGetComponent<InventoryUI>(out InventoryUI inventory)) {
                this.inventory = inventory;
                uis.Add(inventory);
            } else if (this.shop == null && child.TryGetComponent<ShopUI>(out ShopUI shop)) {
                this.shop = shop;
                uis.Add(shop);
            }
        }
    }

    void Start() {
    }

    void Update() {
    }

    public bool IsAnyUIOpened() {
        foreach (BaseUI ui in uis) {
            if (ui.IsOpened()) {
                return true;
            }
        }

        return false;
    }

    public void CloseAll() {
        foreach (BaseUI ui in uis) {
            ui.Close();
        }
    }
}
