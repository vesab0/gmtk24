using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outlinescripts : MonoBehaviour
{
    public float overlapRadius = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, overlapRadius);

        if (colliders.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(){
        Destroy(gameObject);
    }
}
