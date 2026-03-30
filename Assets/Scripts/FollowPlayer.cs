using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;

    // LateUpdate c mieux pour gérer la caméra.
    void LateUpdate()
    {
        // Ici on est a un super FPS
        //transform.localPosition = player.position;

        transform.localPosition = player.position + offset;
    }

}
