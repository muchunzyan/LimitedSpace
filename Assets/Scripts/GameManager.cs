using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isDead;
    public Text coinsText, scoreText;
    private int _collectedCoins;
    private float _score;

    private void FixedUpdate()
    {
        _score += Time.fixedDeltaTime;
        scoreText.text = ((int)_score).ToString();
    }

    public void PlayerDeath()
    {
        Destroy(GameObject.FindWithTag("Player"));
        isDead = true;
        
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + _collectedCoins);

        if (PlayerPrefs.GetInt("HighScore") < (int)_score)
        {
            PlayerPrefs.SetInt("HighScore", (int)_score);
        }
        
        SceneManager.LoadScene("Game");
    }

    public void IncreaseCoins()
    {
        _collectedCoins++;
        coinsText.text = $"Coins: {_collectedCoins}";
    }
}
