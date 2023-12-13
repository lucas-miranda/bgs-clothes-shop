using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour {
    /// Player is near this interactable.
    private Interactable nearInteractable;

    void Start() {
    }

    void Update() {
    }

    public void OnInteract(InputValue value) {
        if (nearInteractable == null) {
            return;
        }

        if (value.isPressed) {
            nearInteractable.Interact();
        }
    }

    /// Player entered on an interactable area.
    public void EnterInteractable(Interactable interactable) {
        nearInteractable = interactable;
    }

    /// Player is going away from an interactable area.
    public void ExitedInteractable(Interactable interactable) {
        if (interactable != nearInteractable) {
            return;
        }

        nearInteractable = null;
    }
}
