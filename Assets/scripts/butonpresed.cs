using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butonpresed : MonoBehaviour
{
    public bool isOnButton;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOnButton = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOnButton = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOnButton = false;
        }
    }
}
