using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreManager scoreManager;
    private bool isAlive = true;

    void Start()
    {
        if (scoreManager == null)
        {
            Debug.LogError("Assign the ScoreManager in the inspector!");
            return;
        }
    }

    public void Die()
    {
        isAlive = false;
        scoreManager.PlayerDied();
    }

    public bool IsAlive()
    {
        return isAlive;
    }
}
