using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class UIManager : MonoBehaviour {
    public InventoryUI inventory;
    public ShopUI shop;

    private List<BaseUI> uis;

    void Awake() {
        Assert.IsNotNull(inventory, "Missing required InventoryUI.");
        Assert.IsNotNull(shop, "Missing required ShopUI.");

        uis = new List<BaseUI> {
            inventory,
            shop,
        };
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
