using UnityEngine;

public class ClothierNPC : MonoBehaviour {
    public ShopUI shopUI;
    public ShopData shopData;

    void Start() {
    }

    void Update() {
    }

    public void Interacted() {
        shopUI.Load(shopData);
        shopUI.Show();
    }
}
