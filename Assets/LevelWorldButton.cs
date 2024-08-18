using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWorldButton : MonoBehaviour
{
    //a

    //funksioni me shku ne nivel
    public void OpenLevelWorld(int levelWorldId){
        string levelWorldName = "LevelWorld"+ levelWorldId;
        SceneManager.LoadScene(levelWorldName);
    }
}





