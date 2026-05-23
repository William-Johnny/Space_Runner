using UnityEngine;
using TMPro;
using System.Collections;

public class CloseCallRight : MonoBehaviour
{
    [SerializeField] TextMeshPro bonusText;
    [SerializeField] GameManager gameManager;
    [SerializeField] int bonusPoints = 10;

    void Start()
    {
        bonusText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle") {
            gameManager.AddScore(bonusPoints);

            StartCoroutine(ShowBonusText());
        }
    }

    IEnumerator ShowBonusText()
    {
        yield return new WaitForSeconds(0.1f);
        if (!gameManager.isGameEnded)
        {
            bonusText.gameObject.SetActive(true);
            bonusText.SetText($"Close call +{bonusPoints}");

            yield return new WaitForSeconds(1f);

            bonusText.gameObject.SetActive(false);
        }
    }
}