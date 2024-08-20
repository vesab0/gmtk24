using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToGame(){
        SceneManager.LoadScene("LevelMap");
    }

    public void GoToMap(){
        SceneManager.LoadScene("LevelMap");
    }

    // public void GoToLevelMenu(){
    //     SceneManager.LoadScene(2);
    // }
    public void GoHome(){
        SceneManager.LoadScene("MainMenuu");
    }

    public void Quit(){
        Application.Quit();
    }

    public void SeeCredits(){
        SceneManager.LoadScene("CreditsScene");
    }
}
