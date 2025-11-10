using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    public static ReferenceManager instance;
    public Transform cameraTransform;
    public static ReferenceManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
    }
}