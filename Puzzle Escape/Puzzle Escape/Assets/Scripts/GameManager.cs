using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentLevel;

    public bool gamePause = false;
    private bool retry = true;

    public GameObject pause;
    public GameObject player;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI pauseText;

    public Button retryButton;

    private PlayerMovement playerMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Retry button resets level
        retryButton.onClick.AddListener(RetryGame);
        // Pause Game if alive
        if (Input.GetKeyDown(KeyCode.Escape) && gamePause == false && playerMovementScript.isAlive == true)
        {
            // Swap camera to player camera
            playerMovementScript.playerCamera.gameObject.SetActive(true);
            playerMovementScript.robotCamera.gameObject.SetActive(false);
            pause.gameObject.SetActive(true);
            pauseText.gameObject.SetActive(true);
            Debug.Log("Paused");
            gamePause = true;
            playerMovementScript.buttonPressed = false;
            Cursor.visible = true;
        }
        //Unpause Game
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePause == true)
        {
            gamePause = false;
            pause.gameObject.SetActive(false);
            pauseText.gameObject.SetActive(false);
            Debug.Log("Unpaused");
            Cursor.visible = false;
        }
    }
    //Resets the player
    public void RetryGame()
    {
        // Prevent the game from loading multiple scenes
        if (retry)
        {
            retry = false;
            SceneManager.LoadScene(currentLevel);
        }
    }
}
