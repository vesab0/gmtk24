using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float cellSize = 1f;
    public cd cd;
    public cm cm;

    public bool cantMove_D;
    public bool cantMove_M;


    public bool CantMoveOfOther_D;
    public bool CantMoveOfOther_M;
    private bool risizingActive;

    
    void Update()
    {      
        if (Input.GetKey(KeyCode.Space))
        {
            risizingActive = true;
            cantMove_D = false;
            cantMove_M = false;
            CantMoveOfOther_D = false;
            CantMoveOfOther_M = false;
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            risizingActive = false;
            cantMove_D = false;
            cantMove_M = false;
            CantMoveOfOther_D = false;
            CantMoveOfOther_M = false;
            
        }  

        Collider2D colliderD = Physics2D.OverlapPoint(transform.position + new Vector3(cellSize,0,0));
        if (colliderD != null)
        {
            if (colliderD.CompareTag("Player"))
            {
                move move = colliderD.GetComponent<move>();
                if (move != null)
                {
                    CantMoveOfOther_D=move.cantMove_D;
                    cantMove_D = true;
                }
            }
        }
        Collider2D colliderM = Physics2D.OverlapPoint(transform.position + new Vector3(-cellSize,0,0));
        if (colliderM != null)
        {
            if (colliderM.CompareTag("Player"))
            {
                move move = colliderM.GetComponent<move>();
                if (move != null)
                {
                    CantMoveOfOther_M=move.cantMove_M;
                    cantMove_M = true;
                }
            }
        }
        
        if(cm.TouchingWall == false && CantMoveOfOther_M == false)
        {        
            if(Input.GetKeyDown(KeyCode.A))
            {
                transform.position = transform.position + new Vector3(-cellSize,0,0);
            }
        }
        if(cd.TouchingWall == false && CantMoveOfOther_D == false)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                    transform.position = transform.position + new Vector3(cellSize,0,0);
            }
        }  
        if(cm.TouchingWall || CantMoveOfOther_M)
        {
            cantMove_M = true;
        }
        else{cantMove_M = false;}     
        if(cd.TouchingWall || CantMoveOfOther_D)
        {
            cantMove_D = true;
        }
        else{cantMove_D = false;}  
    }
}