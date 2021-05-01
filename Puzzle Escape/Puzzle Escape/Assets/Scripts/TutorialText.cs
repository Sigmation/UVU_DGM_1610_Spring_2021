using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    private PlayerMovement playerMovementScript;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        // If player is whitin radis of the button and hasnt used it display tutorial
        if (playerMovementScript.buttonRadias == true & playerMovementScript.buttonPressed == false && gameManagerScript.gamePause == false)
        {
            tutorialText.gameObject.SetActive(true);
        }
        // If player leaves radis of the button hide tutorial
        else if (playerMovementScript.buttonRadias == false)
        {
            tutorialText.gameObject.SetActive(false);
        }
        // If player used the button hide tutorial
        else if (playerMovementScript.buttonPressed == true)
        {
            tutorialText.gameObject.SetActive(false);
        }
        // If game is paused hide toutrial text
        else if (playerMovementScript.buttonPressed == true)
        {
            tutorialText.gameObject.SetActive(false);
        }
    }
}
