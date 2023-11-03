using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : AbstractSingleton<GameManager>
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject victoryPanel;

    private int lives = 5;
    public void EndGame()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void Retry()
    {
        string loadScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(loadScene);
    }
    public void NextLevel()
    {
        Debug.Log("Next level unavailable");
    }
    public void DecreaseLives()
    {
        lives--;

        if (lives <= 0)
        {
            lives = 0;

            EndGame();
        }

        UIManager.Instance.UpdateLivesUI(lives);
    }
    public void GameWin()
    {
        victoryPanel.SetActive(true);
    }
}