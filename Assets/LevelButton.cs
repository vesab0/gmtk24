using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuScript : MonoBehaviour
{
    //a
    public Button[] buttons;

    private void Awake(){
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for(int i=0; i< buttons.Length; i++ ){
            buttons[i].interactable = false;
        }
        for (int i=0; i<unlockedLevel; i++){
            buttons[i].interactable = true;
        }
    }

    //funksioni me shku ne nivel levelId: nr. i nivelit + nr. i world
    public void OpenLevel(int levelId){
        string levelName = "Level"+ levelId;
        SceneManager.LoadScene(levelName);
    }
}


//per me u unlock nivelet tjera te finish point script a najsen duhet me add:
//1. Unity.Scenemanager
//void UnlockNewLevel(){ 
//     if(SceneManager.GetActiveScene().buildIndex >=PlayerPrefs.GetInt("ReachedIndex")){
//         PlayerPrefs.SetInt("ReachedIndex",SceneManager.GetActiveScene().buildIndex +1);
//         PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1)+ 1);
//         PlayerPrefs.Save();
//     }
// }
//call function menihere si e kryn

