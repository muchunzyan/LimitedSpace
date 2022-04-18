using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text highScoreText, coinsText;
    
    private void Start()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore")}";
        coinsText.text = $"Coins: {PlayerPrefs.GetInt("Coins")}";
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
