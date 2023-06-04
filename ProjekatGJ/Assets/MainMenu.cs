using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayNowButton()
    {
        SceneManager.LoadScene("GameJam");
        // SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}