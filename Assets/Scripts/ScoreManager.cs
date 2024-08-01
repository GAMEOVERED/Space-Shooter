using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public PlayerController playerController;

    private int score = 0;
    private bool isPlayerAlive = true;

    void Start()
    {
        if (scoreText == null || playerController == null)
        {
            Debug.LogError("Assign all UI elements and PlayerController in the inspector!");
            return;
        }

       // UpdateScoreText();
        //StartCoroutine(IncrementScore());
    }


    private void Update()
    {
        UpdateScoreText();
        StartCoroutine(IncrementScore());
    }
    IEnumerator IncrementScore()
    {
        while (isPlayerAlive)
        {
            yield return new WaitForSeconds(2f);
            if (isPlayerAlive)
            {
                score += 1;
                UpdateScoreText();
            }
        }
    }

    public void PlayerDied()
    {
        isPlayerAlive = false;
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
