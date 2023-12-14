using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public int money;
    public List<ItemData> items = new List<ItemData>();

    public static Inventory Instance { get; private set; }

    void Awake() {
        Instance = this;
    }

    void Start() {
    }

    void Update() {
    }

    public void ReceiveMoney(int amount) {
        money += amount;
    }

    public bool SpendMoney(int amount) {
        if (money < amount) {
            return false;
        }

        money -= amount;
        return true;
    }

    public void AddItem(ItemData item) {
        items.Add(item);

        if (GameUtil.TryGetPlayer(out GameObject player)) {
            player.SendMessage("ReceivedItem", item, SendMessageOptions.DontRequireReceiver);
        }
    }

}
