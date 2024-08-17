using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public CM CM;
    public CD CD;
    private bool _isMoving;
   public Rigidbody2D rotatingCubeRigidbody;
   public float rollSpeed = 5;
   void Start(){
    {Debug.Log("you have 1 parent");}}
    
    void Update()
{

    
    if (_isMoving) return;
    if (transform.parent != null){}
    if(Input.GetKey(KeyCode.A)){
        if(CM.TouchingWall){
            GameObject parentObject = GameObject.FindGameObjectWithTag("bossi");
            transform.SetParent(parentObject.transform);
            gameObject.tag="Player";
        }
        else{Assemble(Vector3.left);gameObject.tag="bossi";}
    } 

    if(Input.GetKey(KeyCode.D)){
        if(CD.TouchingWall){
            GameObject parentObject = GameObject.FindGameObjectWithTag("bossi");
            transform.SetParent(parentObject.transform);
            gameObject.tag="Player";
        }
        else{Assemble(Vector3.right);gameObject.tag="bossi";}
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
