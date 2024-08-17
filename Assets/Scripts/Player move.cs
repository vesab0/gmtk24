using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{

private bool _isMoving;
   public Rigidbody2D rotatingCubeRigidbody;
   public float rollSpeed = 5;
    void Update()
{
    if (_isMoving) return;
    if(Input.GetKey(KeyCode.A)) Assemble(Vector3.left);
    if(Input.GetKey(KeyCode.D)) Assemble(Vector3.right);
    
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
