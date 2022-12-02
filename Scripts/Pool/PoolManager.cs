using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpawnableItem
{
    public GameObject ObjectToCreate;
    public int Amount;
}

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    [SerializeField]
    private SpawnableItem[] objectsToSpawn;

    private Dictionary<GameObject, Queue<GameObject>> objectsQueue = 
        new Dictionary<GameObject, Queue<GameObject>>();

    private void Awake()
    {
        SingletonPattern();
    }

    private void SingletonPattern()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PopulateQueues();
    }

    // Used for debbuging the content inside the pool manager.
    private void DebugDictionaryContent()
    {
        foreach (var obj in objectsQueue.Keys)
            foreach (var queueObj in objectsQueue[obj])
                print("I am a " + obj + "and my queue has " + queueObj);
    }

    private void PopulateQueues()
    {
        foreach (var objectToSpawn in objectsToSpawn)
        {
            // Create new queue that will be used to populate the queue dict.
            Queue<GameObject> thisObjectQueue = new Queue<GameObject>();

            // Create and populate each object queue.
            for (int j = 0; j < objectToSpawn.Amount; ++j)
            {
                var objectCreated = CreateNew(objectToSpawn.ObjectToCreate, thisObjectQueue);
                thisObjectQueue.Enqueue(objectCreated);
            }

            // Move this queue to the queues dict: Bullets => Queues of bullets.
            objectsQueue.Add(objectToSpawn.ObjectToCreate, thisObjectQueue);
        }
    }

    private GameObject CreateNew(GameObject objectToCreate, Queue<GameObject> thisObjectQueue)
    {
        GameObject objectCreated = Instantiate(objectToCreate);
        objectCreated.transform.SetParent(this.transform);
        objectCreated.SetActive(false);
        objectCreated.GetComponent<PoolHandler>()?.SetMyQueue(thisObjectQueue);

        return objectCreated;
    }

    // Called via script to create stuff instead of Instantiate().
    public GameObject Spawn(GameObject gameObjectToSpawn)
    {
        Queue<GameObject> queueThisObjectIsIn;

        if (objectsQueue.TryGetValue(gameObjectToSpawn, out queueThisObjectIsIn))
        {
            // If I need more than the initial limit of this object.
            if (queueThisObjectIsIn.Count == 0)
            {
                // Extend this queue.
                return CreateNew(gameObjectToSpawn, queueThisObjectIsIn);
            }
            else
            {
                GameObject gameObjectUsed = queueThisObjectIsIn.Dequeue();
                if (gameObjectUsed != null)
                {
                    return gameObjectUsed;
                }
                else
                {
                    return CreateNew(gameObjectToSpawn, queueThisObjectIsIn);
                }
            }
        }
        // This Object is not in the Objects Queue Dictionary.
        else
        {
            return AddToObjectsQueue(gameObjectToSpawn);
        }
    }

    public void Despawn(GameObject gameObjectToDespawn, Queue<GameObject> queueThisObjectIsIn)
    {
        if (queueThisObjectIsIn != null)
        {
            if (objectsQueue.ContainsValue(queueThisObjectIsIn))
            {
                queueThisObjectIsIn.Enqueue(gameObjectToDespawn);
            }
        }
        // If is not part of the object pooling.
        else
        {
            Destroy(gameObjectToDespawn);
        }
    }

    private GameObject AddToObjectsQueue(GameObject gameObjectToSpawn)
    {
        Queue<GameObject> newQueue = new Queue<GameObject>();
        objectsQueue.Add(gameObjectToSpawn, newQueue);

        return CreateNew(gameObjectToSpawn, newQueue);
    }

    // Called like the normal Instantiate() from Unity.
    public static GameObject Use(GameObject gameObject, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        var objectCreated = PoolManager.Instance.Spawn(gameObject);
        objectCreated.transform.position = spawnPosition;
        objectCreated.transform.rotation = spawnRotation;
        objectCreated.SetActive(true);

        return objectCreated;
    }
}
