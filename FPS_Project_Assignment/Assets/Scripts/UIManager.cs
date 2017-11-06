using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject Options_GUI_Holder;


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
        if (Options_GUI_Holder.activeInHierarchy == false)
        {
            Options_GUI_Holder.SetActive(true);
        }
        else Options_GUI_Holder.SetActive(false);
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
