using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolHandler : MonoBehaviour
{
    private Queue<GameObject> myQueue;

    public void SetMyQueue(Queue<GameObject> queue)
    {
        myQueue = queue;
    }

    
    public void DismissSelf()
    {
        gameObject.SetActive(false);
        PoolManager.Instance.Despawn(gameObject, myQueue);
    }
}
