using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Assertions;

public class PlayerMenu : MonoBehaviour {
    public UIManager uiManager;

    void Start() {
        Assert.IsNotNull(uiManager, "Missing required UIManager.");
    }

    void Update() {
    }

    public void OnMenu(InputValue value) {
        if (value.isPressed) {
            if (uiManager.IsAnyUIOpened()) {
                uiManager.CloseAll();
            } else {
                uiManager.inventory.Open();
            }
        }
    }
}
