using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public Scene_Manager() { }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void ExitGame()
    {
        Application.Quit();

    }
}
