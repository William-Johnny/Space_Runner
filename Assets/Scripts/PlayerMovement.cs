using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    [SerializeField] float sidewaysForce = 500f;

    // FixedUpdate tout est synro
    void FixedUpdate() {
        // Time.deltaTime est independant du FrameRate du jeu.
        // rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // Les Input il faut mieux les mettre dans le
        // ForceMode.VelocityChange
        if (Input.GetKey("d")) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a")) {
            rb.AddForce(- sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
