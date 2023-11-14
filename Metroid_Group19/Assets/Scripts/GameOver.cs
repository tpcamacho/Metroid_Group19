using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Tyler Camacho and Nataly Vazquez
//11/13/23
//switches to game over scene

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
