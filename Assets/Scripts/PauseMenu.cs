using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject pausePanel;
    public GameObject scoreText;
    private bool isPaused = false;

    void Start()
    {
        if (pausePanel == null || pauseButton == null || resumeButton == null || scoreText == null)
        {
            Debug.LogError("Assign all UI elements in the inspector!");
            return;
        }

        //pauseButton.onClick.AddListener(PauseGame);
        //resumeButton.onClick.AddListener(ResumeGame);

        pausePanel.SetActive(false); // Ensure the pause panel is inactive at start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
            
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("S1");
    }

}
