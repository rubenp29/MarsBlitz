using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] private Transform nextRoom;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Artur"))
        {
            other.transform.position = nextRoom.position;
        }
    }
}
