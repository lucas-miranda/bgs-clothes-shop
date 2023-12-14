using UnityEngine;

public class Interactable : MonoBehaviour {
    void Start() {
    }

    void Update() {
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (!col.TryGetComponent<PlayerInteract>(out PlayerInteract interactor)) {
            return;
        }

        interactor.EnterInteractable(this);
        SendMessage("InteractorEntered", interactor, SendMessageOptions.DontRequireReceiver);
    }

    void OnTriggerExit2D(Collider2D col) {
        if (!col.TryGetComponent<PlayerInteract>(out PlayerInteract interactor)) {
            return;
        }

        interactor.ExitedInteractable(this);
        SendMessage("InteractorExited", interactor, SendMessageOptions.DontRequireReceiver);
    }

    public void Interact(PlayerInteract interactor) {
        SendMessage("Interacted", interactor);
    }
}
