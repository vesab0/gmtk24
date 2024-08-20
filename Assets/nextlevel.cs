using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class nextlevel : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnlockNewLevel();
            SceneManager.LoadScene("Level12");
        }
    }
    
    public void UnlockNewLevel(){ 
     if(SceneManager.GetActiveScene().buildIndex >=PlayerPrefs.GetInt("ReachedIndex")){
         PlayerPrefs.SetInt("ReachedIndex",SceneManager.GetActiveScene().buildIndex +1);
         PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1)+ 1);
         PlayerPrefs.Save();
     }
 }
}
