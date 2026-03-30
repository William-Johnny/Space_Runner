using UnityEngine;

public class PlayerSquichEffect : MonoBehaviour
{

    Vector3 startScale;
    Vector3 startPosition;
    [SerializeField] Vector2 squishyness = Vector2.one;

    [SerializeField] Rigidbody PlayerRb;

    [SerializeField] Transform playerCube;
    
    [SerializeField] Vector2 velocityRange = new Vector2(0, 15);

    void Start () {
        startScale = playerCube.localScale;
        startPosition = playerCube.localPosition;
    }

    void Update () {
        float velocity = Mathf.Clamp01(Mathf.InverseLerp(velocityRange.x, velocityRange.y, Mathf.Abs( PlayerRb.linearVelocity.x)));
        float scaleY = velocity * squishyness.y;

        playerCube.localScale = new Vector3(
            startScale.x + velocity * squishyness.x,
            startScale.y + scaleY,
            startScale.z);

        playerCube.localPosition = new Vector3(startPosition.x, startPosition.y - Mathf.Abs(scaleY) * 0.5f, startPosition.z);
    }
}
