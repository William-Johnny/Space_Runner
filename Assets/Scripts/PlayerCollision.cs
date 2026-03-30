using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] PlayerCollision playerCollision;

    GameManager gameManager;

    void Start() {
        gameManager = (GameManager)FindFirstObjectByType(typeof(GameManager));
    }
    

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Obstacle") {
            playerCollision.enabled = false; 
            
            gameManager.EndGame();
        } 
    }

    void Update () {
        if (transform.position.y < -2f) {
            gameManager.EndGame();
        }
    }
}
