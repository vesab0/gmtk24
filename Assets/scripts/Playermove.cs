using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public CM CM;
    public CD CD;

    public CP CP;

    public GameObject Tag2;
    private bool _isMoving;
   public Rigidbody2D rotatingCubeRigidbody;
   public float rollSpeed = 5;

    void Update()
{

    if (_isMoving) return;
    if(Input.GetKey(KeyCode.A)){
        if(CM.TouchingWall)
        {
            Instantiate(Tag2, transform.position, Quaternion.identity);
            GameObject parentObject = GameObject.FindGameObjectWithTag("bossi");
            transform.SetParent(parentObject.transform);
            gameObject.tag="Player";
        }
        if(CP.TouchingG){Assemble(Vector3.left);gameObject.tag="bossi";}
    } 

    if(Input.GetKey(KeyCode.D)){
        if(CD.TouchingWall)
        {
            Instantiate(Tag2, transform.position, Quaternion.identity);
            GameObject parentObject = GameObject.FindGameObjectWithTag("bossi");
            transform.SetParent(parentObject.transform);
            gameObject.tag="Player";
        }
        if(CP.TouchingG){Assemble(Vector3.right);gameObject.tag="bossi";}
    } 
    
    
    void Assemble(Vector3 dir)
    {
        var anchor = transform.position + (Vector3.down + dir)*0.5f;
        var axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Roll(anchor, axis));
        
    }
}
    IEnumerator Roll(Vector3 anchor, Vector3 axis){
        _isMoving = true;
        for (int i = 0; i< (90/ rollSpeed); i++){
            transform.RotateAround(anchor,axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        _isMoving = false;
    }
}
