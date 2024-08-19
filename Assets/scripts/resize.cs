using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
    public controller controller;
    public move move; 

    public cm cm;
    public cd cd;
    public cn cn;
    string prefabName;

    public GameObject qeliza;
    public static bool canResize = false;
    public butonpresed butonpresed;

    private int myID = 0;
    private int lastPlaceDjatht=0;
    private int lastPlaceMajt=0;
    public float overlapRadius = 0.1f;
    
    void Start()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, overlapRadius);

        if (colliders.Length > 1)
        {
            Destroy(gameObject);
        }

        butonpresed.isOnButton = false;
        if (controller.direction == 1)
        {
            myID = lastPlaceDjatht;
        }
        else if (controller.direction == -1)
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

        if (butonpresed.isOnButton && canResize)
        {
            Vector3 myPosition = transform.position;

            if (!cm.TouchingWall && !cm.TouchingGuy)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                
                    Vector3 newPosition = myPosition + new Vector3(-1, 0, 0);

                    Instantiate(qeliza, newPosition, Quaternion.identity);  

                    lastPlaceMajt--;
                    controller.GetComponent<controller>().createdleft();
                }
            }
            if (!cd.TouchingWall && !cd.TouchingGuy)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    Vector3 newPosition = myPosition + new Vector3(1, 0, 0);

                    Instantiate(qeliza, newPosition, Quaternion.identity);  
                    
                    lastPlaceDjatht++;
                    controller.GetComponent<controller>().createdright();
                }
            }
            if (!cn.TouchingWall && !cn.TouchingGuy)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    Vector3 newPosition = myPosition + new Vector3(0, 1, 0);

                    Instantiate(qeliza, newPosition, Quaternion.identity);  

                    lastPlaceDjatht++;
                    controller.GetComponent<controller>().createdright();
                }
            }
        }
    }
//come down come down come down

}