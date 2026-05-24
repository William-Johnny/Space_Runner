using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreText;

    [SerializeField] float slowness = 2f;

    public bool isGameEnded = false;
    public float score = 0;

    void Update()
    {
        if (!isGameEnded)
        {
            score += Time.deltaTime * 10f;

            scoreText.SetText(score.ToString("0"));
        }
        else
        {
            scoreText.fontSize = 50f;
            scoreText.color = Color.red;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void EndGame () {
        if (!isGameEnded) {
            isGameEnded = true;

            StartCoroutine(RestartLevel());
        }
        
    }

    IEnumerator RestartLevel() {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(1f);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
