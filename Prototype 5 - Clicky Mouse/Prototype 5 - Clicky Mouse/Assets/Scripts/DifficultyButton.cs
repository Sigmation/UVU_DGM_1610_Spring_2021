using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    // Sets up the Game difficulty
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        // Identifys the Button
        button = GetComponent<Button>();
        // Click the menu buttons to set difficult
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Sets the difficulty of the game
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked!");
        // Starts the game
        gameManager.StartGame(difficulty);
    }
}
