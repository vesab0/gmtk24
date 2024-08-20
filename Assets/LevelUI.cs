using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public static bool isPaused;

     public void PausePlay()
    {
        Time.timeScale = 0f;
        isPaused = false;
    }

    public void ResumePlay()
    {
        Time.timeScale = 1f;
        isPaused = true;
    }
   
    public void Restart(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
