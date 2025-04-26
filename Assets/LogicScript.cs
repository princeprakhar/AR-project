using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public int scoreIncrement = 1; // Default value to add when using context menu
    public GameObject gameOverScreen;

    [ContextMenu("Increase Score")]
    public void IncreaseScoreFromContextMenu()
    {
        // This parameterless method will be called from the context menu
        addScore(scoreIncrement);
    }

    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        Debug.Log(scoreText);
        scoreText.text = playerScore.ToString();
    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}