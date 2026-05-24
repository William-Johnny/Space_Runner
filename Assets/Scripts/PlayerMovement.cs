using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    [SerializeField] float sidewaysForce = 500f;
    GameManager gameManager;

    float keyHoldTime = 0f;

    void Start() {
        gameManager = (GameManager)FindFirstObjectByType(typeof(GameManager));
    }
    void FixedUpdate()
    {
        bool keyPressed = false;

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            keyPressed = true;
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            keyPressed = true;
        }

        if (keyPressed)
        {
            keyHoldTime += Time.deltaTime;

            if (keyHoldTime > 4f)
            {
                gameManager.EndGame();
            }
        }
        else
        {
            keyHoldTime = 0f;
        }
    }
}