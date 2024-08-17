using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
    public creatercontroller creatercontroller;
    public Playermove Playermove; 
    public GameObject katrori;
    public bool canResize = false;
    public bool isOnButton = false;

    private int myID = 0;
    
    public static int lastPlaceMajt = 0;
    public static int lastPlaceDjatht = 0;
    public static int lastPlaceNalt = 0;
    void Start()
    {
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
            Playermove.rollSpeed = 0f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            canResize = false;
            Playermove.rollSpeed = 6f;
        }

        if (isOnButton && canResize)
        {
            Vector3 myPosition = transform.position;

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (myID == lastPlaceMajt)
                {
                    Vector3 newPosition = myPosition + new Vector3(1, 0, 0);
                    Instantiate(katrori, newPosition, Quaternion.identity);
                    lastPlaceMajt--;
                    creatercontroller.GetComponent<creatercontroller>().createdleft();
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (myID == lastPlaceDjatht)
                {
                    Vector3 newPosition = myPosition + new Vector3(1, 0, 0);
                    Instantiate(katrori, newPosition, Quaternion.identity);
                    lastPlaceDjatht++;
                    creatercontroller.GetComponent<creatercontroller>().createdright();
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (myID == lastPlaceNalt)
                {
                    Vector3 newPosition = myPosition + new Vector3(0, 1, 0);
                    Instantiate(katrori, newPosition, Quaternion.identity);
                    lastPlaceNalt++;
                    //creatercontroller.GetComponent<creatercontroller>().createdup();
                }
            }
        }
    }

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
