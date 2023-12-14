using UnityEngine;

public class Interactable : MonoBehaviour {
    void Start() {
    }

    void Update() {
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (!col.TryGetComponent<PlayerInteract>(out PlayerInteract interact)) {
            return;
        }

        interact.EnterInteractable(this);
    }

    void OnTriggerExit2D(Collider2D col) {
        if (!col.TryGetComponent<PlayerInteract>(out PlayerInteract interact)) {
            return;
        }

        interact.ExitedInteractable(this);
    }

    public void Interact() {
        SendMessage("Interacted");
    }
}
