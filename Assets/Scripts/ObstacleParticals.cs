using UnityEngine;

public class ObstacleParticals : MonoBehaviour
{

    [SerializeField] ParticleSystem ps;

    [SerializeField] GameObject cube;

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player") {
            ps.Play();
            Destroy(cube);
        }
    }
    
}
