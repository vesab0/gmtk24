using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float cellSize = 1f;
    public cd cd;
    public cm cm;
    public bool canmovetag;
    private Vector3 potentialL;
    private Vector3 potentialD;
    private bool kivenL;
    private bool kivenD;
    private bool kivenfrL;
    private bool kivenfrD;
    public bool cantMove;
    

    // Start is called before the first frame update
    void Start()
    {
        potentialL = transform.position + new Vector3(-cellSize,0,0);
        potentialD = transform.position + new Vector3(cellSize,0,0);

        kivenfrL = true;
        kivenfrD = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;
        Collider2D colliderD = Physics2D.OverlapPoint(potentialD);
        
        Collider2D colliderL = Physics2D.OverlapPoint(potentialL);

        
        if(colliderL != null){
            if (colliderL.CompareTag("Player")){
                if (cm.CantMoveOfOther == true){
                    kivenfrL = false;
                }
                else{
                    kivenfrL = true;
                }
            }
        }
        if(colliderD != null){
            if (colliderD.CompareTag("Player")){
                if (!cd.CantMoveOfOther){
                    kivenfrD = true;
                }
                else{
                    kivenfrD = false;
                }
            }  
        }
                

        if(cm.TouchingWall||cd.TouchingWall)
        {
            cantMove = true;
        }
        else{cantMove = false;}

        if(cm.TouchingWall == false && kivenfrL == true){
                    
            if(Input.GetKeyDown(KeyCode.A))
            {
                transform.position = transform.position + new Vector3(-cellSize,0,0);

                potentialL = transform.position + new Vector3(-cellSize, 0, 0);
                potentialD = transform.position + new Vector3(cellSize, 0, 0);
            }
        }
        
        if(cd.TouchingWall == false && kivenfrD == true){
            if(Input.GetKeyDown(KeyCode.D))
            {
                transform.position = transform.position + new Vector3(cellSize,0,0);

                potentialL = transform.position + new Vector3(-cellSize, 0, 0);
                potentialD = transform.position + new Vector3(cellSize, 0, 0);
            }
        }  
    }
}