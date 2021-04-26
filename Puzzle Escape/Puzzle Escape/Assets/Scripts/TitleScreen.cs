using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{

    public Button playButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }
    
    // Start game
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    //Quit game
    public void QuitGame()
    {
        Application.Quit();
    }
}
