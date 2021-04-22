using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText, gameOverText;
    public Button resetButton;
    public GameObject titleScreen;
    
    
    IEnumerator SpawnTarget()
    {
        // Spawns Targets at random while the game is active
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    }
    
    // Changes the score based on the targets score
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Ends the Game
    public void GameOver()
    {
        // Displays GameOver! and the reset button
        gameOverText.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Resets the game
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Start game after difficult is selected
    public void StartGame(int difficulty)
    {
        UpdateScore(0);
        scoreText.text = "Score: " + score;
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
    }
}
