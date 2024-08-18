using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playermove : MonoBehaviour
{
    public CM CM;
    public CD CD;

    public CP CP;

    public BSM BSM;

    public BSD BSD;

    public Transform parentTransform;

    private bool _isMoving;
   public Rigidbody2D rotatingCubeRigidbody;
   public float rollSpeed = 5;
   public string tagToExclude = "help";


    void Update()
    {

        GameObject bossObject = GameObject.FindGameObjectWithTag("bossi");
        if (_isMoving) return;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene currentScene = SceneManager.GetActiveScene();

        // Reload the currently active scene
            SceneManager.LoadScene(currentScene.buildIndex);
        }
        



        if(!CM.TouchingPlayer && !CM.TouchingWall)
        {
            gameObject.tag="potencialbossiM";
            if(gameObject.name == BSM.lowestObject.name)
            {           
                if(Input.GetKey(KeyCode.A))
                {
                    gameObject.tag="bossi";
                    Assemble(Vector3.left);  
                }
            } 
        }
        if(!CD.TouchingPlayer && !CD.TouchingWall)
        { 
            gameObject.tag="potencialbossiD";
            if(gameObject.name == BSD.lowestObject.name)
            {     
                if(Input.GetKey(KeyCode.D))
                {
                    gameObject.tag="bossi";
                    Assemble(Vector3.right);  
                } 
            }
        }
        if((CM.TouchingPlayer || CD.TouchingPlayer) && transform.position.y >= bossObject.transform.position.y - 0.5f)
        {
            GameObject parentObject = GameObject.FindGameObjectWithTag("bossi");
            transform.SetParent(parentObject.transform);
        }
        if(transform.position.y >= bossObject.transform.position.y - 0.5f)
        {
            
        }

        //if(!CD.TouchingWall && (Input.GetKey(KeyCode.D)))
        //{
        //    Assemble(Vector3.right);
        //    gameObject.tag="bossi";
        //} 
        


        
        void Assemble(Vector3 dir)
        {
            var anchor = transform.position + (Vector3.down + dir)*0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Roll(anchor, axis));
            
        }
    }
    IEnumerator Roll(Vector3 anchor, Vector3 axis){
        _isMoving = true;
        for (int i = 0; i< (90/ rollSpeed); i++)
        {
            transform.RotateAround(anchor,axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

            foreach (Transform child in parentTransform)
            {
                if (child.CompareTag(tagToExclude))
                {
                    continue;
                }
                child.SetParent(null);
            }
        gameObject.tag="Player";
        _isMoving = false;
    }
}
