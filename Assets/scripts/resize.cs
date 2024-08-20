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
    public GameObject outline;
    public static bool canResize = false;
    public butonpresed butonpresed;
    public butonpresed butonpresed1;
    
    public butonpresed butonpresed2;
    
    public butonpresed butonpresed3;

    private int myID = 0;
    private int lastPlaceDjatht=0;
    private int lastPlaceMajt=0;
    public float overlapRadius = 0.1f;
    private Rigidbody2D rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, overlapRadius);

        if (colliders.Length > 1)
        {
            Destroy(gameObject);
        }

        butonpresed.isOnButton = false;
        butonpresed1.isOnButton = false;
        butonpresed2.isOnButton = false;
        butonpresed3.isOnButton = false;
        if (controller.direction == 1)
        {
            myID = lastPlaceDjatht;
        }
        else if (controller.direction == -1)
        {
            myID = lastPlaceMajt;   
        }
    }

    void FixedUpdate(){
        if (Input.GetKey(KeyCode.Space))
        {
            
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
               
            rb.constraints = RigidbodyConstraints2D.None;
            
        }
    }



    void Update()
    {   
        if(gameObject.CompareTag("Player")){

        if (Input.GetKey(KeyCode.Space))
        {
            canResize = true;
            move.cellSize = 0f;
            this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            canResize = false;
            move.cellSize = 1f;
            this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1f);
            
        }

        if ((butonpresed.isOnButton||butonpresed1.isOnButton||butonpresed2.isOnButton||butonpresed3.isOnButton) && canResize)
        {       
            Vector3 myPosition = transform.position;

            if (!cm.TouchingWall && !cm.TouchingGuy)
            {
                Vector3 newPositionoutline = myPosition + new Vector3(-1, 0, 0);
                Instantiate(outline, newPositionoutline, Quaternion.identity);

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
                Vector3 newPositionoutline = myPosition + new Vector3(1, 0, 0);
                Instantiate(outline, newPositionoutline, Quaternion.identity);

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
                Vector3 newPositionoutline = myPosition + new Vector3(0, 1, 0);
                Instantiate(outline, newPositionoutline, Quaternion.identity);

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
    }
//come down come down come down

}