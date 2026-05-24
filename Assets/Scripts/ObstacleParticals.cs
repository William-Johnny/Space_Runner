using UnityEngine;

public class ObstacleParticals : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    [SerializeField] GameObject cube;

    [SerializeField] AudioSource hitSound;

    AudioSource musicSource;

    void Start()
    {
        musicSource = GameObject.FindGameObjectWithTag("Music")
                        .GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ps.Play();
            musicSource.Stop();
            hitSound.Play();
            Destroy(cube);
        }
    }
}