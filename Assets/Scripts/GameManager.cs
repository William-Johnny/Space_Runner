using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreText;

    [SerializeField] float slowness = 2f;

    bool isGameEnded = false;

    void Update () {

        if (!isGameEnded) {
            float score = Time.timeSinceLevelLoad * 10f;
            // Avec 0 je lui dit que je veux pas de décimal
            scoreText.SetText(score.ToString("0"));
        } else {
            scoreText.fontSize = 50f;
            scoreText.color =  Color.red;
        }
        
    }

    public void EndGame () {
        if (!isGameEnded) {
            isGameEnded = true;
            Debug.Log("GameOver");

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
