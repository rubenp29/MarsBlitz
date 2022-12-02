using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    [SerializeField] private GameObject myPlayerPositon;

    private Transform myPlayer;
    // Start is called before the first frame update

    private void Awake()
    {
        myPlayer = myPlayerPositon.GetComponent<Transform>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(myPlayer);
    }
}
