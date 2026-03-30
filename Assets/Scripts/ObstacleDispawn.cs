using UnityEngine;

public class DestroyWhenBelowY : MonoBehaviour
{
    [SerializeField] private float destroyYLevel = -10f;

    void Update()
    {
        if (transform.position.y <= destroyYLevel)
        {
            Destroy(gameObject);
        }
    }
}