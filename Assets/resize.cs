using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
    public creatercontroller creatercontroller;
    public move move; 

    public cm cm;
    public cd cd;
    //public cn cn;


    public GameObject qeliza;
    public static bool canResize = false;
    public bool isOnButton = false;

    private int myID = 0;
    private int lastPlaceDjatht=0;
    private int lastPlaceMajt=0;
    
    void Start()
    {
        isOnButton = false;
        gameObject.tag="Player";
        if (creatercontroller.direction == 1)
        {
            myID = lastPlaceDjatht;
        }
        else if (creatercontroller.direction == -1)
        {
            myID = lastPlaceMajt;   
        }
    }

    void Update()
    {   
        if (Input.GetKey(KeyCode.Space))
        {
            canResize = true;
            move.cellSize = 0f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            canResize = false;
            move.cellSize = 1f;
        }

        if (isOnButton && canResize)
        {
            Vector3 myPosition = transform.position;

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (!cm.TouchingWall)
                {
                    Vector3 newPosition = myPosition + new Vector3(-1, 0, 0);
                    Instantiate(qeliza, newPosition, Quaternion.identity);
                    lastPlaceMajt--;
                    creatercontroller.GetComponent<creatercontroller>().createdleft();
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (!cd.TouchingWall)
                {
                    Vector3 newPosition = myPosition + new Vector3(1, 0, 0);
                    Instantiate(qeliza, newPosition, Quaternion.identity);
                    lastPlaceDjatht++;
                    creatercontroller.GetComponent<creatercontroller>().createdright();
                }
            }
            
        }
    }
//come down come down come down
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("button"))
        {
            isOnButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("button"))
        {
            isOnButton = false;
        }
    }
}