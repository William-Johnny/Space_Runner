using UnityEngine;

public class CollisionMovement : MonoBehaviour
{
    
    [SerializeField] Rigidbody rb;

    [SerializeField] float forwardForce = - 500f;
    bool shouldMove = true;

    void FixedUpdate() {
        if (shouldMove) {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player") {
            shouldMove = false;
        }
    }
}