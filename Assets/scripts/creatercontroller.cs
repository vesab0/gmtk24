using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatercontroller : MonoBehaviour
{
    public int direction = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createdleft(){
        direction = -1;
        Debug.Log(direction);
    }
    public void createdright(){
        direction = 1;
        Debug.Log(direction);
    }
}
