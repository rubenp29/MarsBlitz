using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    [SerializeField] private float destructionForce = 200;
    private Rigidbody2D myRigidbody = null;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void GetForce(Vector2 bulletDirection)
    {
        myRigidbody.AddForce(bulletDirection * destructionForce);

    }

    //private void OnEnable()
    //{
    //    myRigidbody.AddForce(Vector2.right * destructionForce);
    //}

}
