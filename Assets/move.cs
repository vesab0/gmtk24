using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float cellSize = 1f;
    public cd cd;
    public cm cm;
    public bool canmovetag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;

        
        
        if(cm.TouchingWall == false){
                
            if(Input.GetKeyDown(KeyCode.A))
            {
                transform.position = transform.position + new Vector3(-cellSize,0,0);
            }
        }
        if(cd.TouchingWall == false){
            if(Input.GetKeyDown(KeyCode.D))
            {
                transform.position = transform.position + new Vector3(cellSize,0,0);
            }
        }  

         
    }
}