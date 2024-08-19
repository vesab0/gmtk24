using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToGame(){
        SceneManager.LoadScene(1);
    }

    public void GoToMap(){
        SceneManager.LoadScene(2);
    }

    // public void GoToLevelMenu(){
    //     SceneManager.LoadScene(2);
    // }
    public void GoHome(){
        SceneManager.LoadScene(0);
    }

    public void Quit(){
        Application.Quit();
    }

    public void SeeCredits(){
        SceneManager.LoadScene(7);
    }
}
