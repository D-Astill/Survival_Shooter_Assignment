using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public void MainMenu()
    {
        //Index 0 is Start Screen
        SceneManager.LoadScene("Main_Menu");
    }

    public void Game_Mode()
    {
        //Index 1 is Game mode Screen
        SceneManager.LoadScene("Game_Mode");
    }

    public void Options()
    {
        //Index 2 is options menu
        SceneManager.LoadScene("Options");
    }
    public void LeaderBoards()
    {
        //Index 3 is leaderboards
        SceneManager.LoadScene("Leaderboards");
    }
    public void SinglePlayer()
    {
        //Index 4 is leaderboards
        SceneManager.LoadScene("Single_Player");
    }
    
    

    public void Quit()
    {
        Debug.Log("Application Attempted Shutdown");
        //Quits the exe
        Application.Quit();
    }
}
