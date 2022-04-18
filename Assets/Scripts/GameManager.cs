using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isDead;
    public Text coinsText, scoreText;
    private int _collectedCoins;
    private float _score;
    public GameObject deathScreen;
    
    private float _scaleTimer;
    private bool _needToIncreaseScale;

    private float _slowTimeTimer;
    private bool _needToIncreaseTime;

    private void FixedUpdate()
    {
        if (isDead) return;
        
        if (_needToIncreaseTime)
            _score += 2 * Time.fixedDeltaTime;
        else
            _score += Time.fixedDeltaTime;
        
        scoreText.text = ((int)_score).ToString();

        _scaleTimer -= Time.fixedDeltaTime;
        if (!_needToIncreaseScale || !(_scaleTimer < 0)) return;
        
        _needToIncreaseScale = false;
        var player = GameObject.FindWithTag("Player");
        player.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        player.transform.position += new Vector3(0.0f, 0.25f, 0.0f);

        _slowTimeTimer -= Time.fixedDeltaTime;
        if (!_needToIncreaseTime || !(_slowTimeTimer < 0)) return;
        
        _needToIncreaseTime = false;
        Time.timeScale = 1;
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

        deathScreen.SetActive(true);
    }

    public void IncreaseCoins()
    {
        _collectedCoins++;
        coinsText.text = $"Coins: {_collectedCoins}";
    }

    public void ScaleDecrease()
    {
        if (!_needToIncreaseScale)
        {
            var player = GameObject.FindWithTag("Player");

            player.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
            player.transform.position -= new Vector3(0.0f, 0.25f, 0.0f);
        }

        _scaleTimer = 5;
        _needToIncreaseScale = true;
    }

    public void SlowTime()
    {
        Time.timeScale = 0.5f;

        _slowTimeTimer = 2.5f;
        _needToIncreaseTime = true;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
