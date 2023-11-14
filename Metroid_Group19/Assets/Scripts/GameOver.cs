using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //plays game again
    public void RetryGame()
    {
        SceneManager.LoadScene(0);
    }

    //quits game
    public void QuitGame()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
