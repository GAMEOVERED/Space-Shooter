using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject resumePanel;
    public GameObject pauseButton;
    public GameObject scoreText;
    public PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
       // player = gameObject.GetComponent<PlayerController>();
        resumePanel.SetActive(false);
        pauseButton.SetActive(true);
        scoreText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
       
        if (player.isAlive)
        {
            resumePanel.SetActive(false);
            pauseButton.SetActive(true);
            scoreText.SetActive(true);
        }
        else
        {
            playerDead(); 
        }

    }

   public void playerDead()
    {
        resumePanel.SetActive(true);
        pauseButton.SetActive(false);
        scoreText.SetActive(false);
    }

    
}
