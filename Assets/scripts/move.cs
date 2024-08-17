using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float moveSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;

        if(Input.GetKey(KeyCode.A))
        {
            movement.x = (transform.right*Time.deltaTime*-moveSpeed).x;
        }
        if(Input.GetKey(KeyCode.D))
        {
            movement.x = (transform.right*Time.deltaTime*moveSpeed).x;
        }
        movement = movement + (Vector2)(transform.position);

        GetComponent<Rigidbody2D>().MovePosition(movement);
    }
}
