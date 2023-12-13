using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour {
    public float speed;

    private Rigidbody2D body;
    private Animator[] animators;
    private Vector2 axis;
    private FaceDirection faceDirection;

    void Start() {
        body = GetComponent<Rigidbody2D>();
        animators = GetComponentsInChildren<Animator>();
    }

    void Update() {
    }

    void FixedUpdate() {
        body.velocity = axis * speed * Time.fixedDeltaTime;
    }

    public void OnMove(InputValue value) {
        axis = value.Get<Vector2>();
        int hDir = System.Math.Sign(axis.x);
        int vDir = System.Math.Sign(axis.y);
        bool isWalking = true;

        if (hDir < 0) {
            faceDirection = FaceDirection.West;
        } else if (hDir > 0) {
            faceDirection = FaceDirection.East;
        } else if (vDir < 0) {
            faceDirection = FaceDirection.North;
        } else if (vDir > 0) {
            faceDirection = FaceDirection.South;
        } else {
            // player isn't moving at all
            isWalking = false;
        }

        foreach (Animator animator in animators) {
            animator.SetBool("Walking", isWalking);
            if (isWalking) {
                // only change face direction when moving
                animator.SetFloat("FaceHorizontal", hDir);
                animator.SetFloat("FaceVertical", vDir);
            }
        }
    }
}
