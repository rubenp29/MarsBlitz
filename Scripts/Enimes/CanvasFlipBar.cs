using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFlipBar : MonoBehaviour
{
    private Quaternion initialRotation;

    private void Awake()
    {
        initialRotation = transform.rotation;
    }

    public void RestoreRotation()
    {
        transform.rotation = initialRotation;
    }
}