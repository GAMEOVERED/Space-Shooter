
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
   public void StartGame()
    {
        SceneManager.LoadScene("S1");
    }

   public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

}
