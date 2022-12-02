using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogArtur : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Artur"))
        {
           
           UIManager.Instance.ShowArturPanel();
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag( "Artur"))
        {
            gameObject.SetActive(false);
        }
    }
}
