using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootConector : MonoBehaviour
{
    public void TripleShoot()
    {
        GetComponentInParent<TripleShoot>().Tripleshoot();
            
    }
}