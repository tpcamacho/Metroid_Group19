using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Tyler Camacho and Nataly Vazquez
//11/13/23
//this switches from the menu to the game scene

public class Menu : MonoBehaviour
{
    //switches to game
    public void StartGame()
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
