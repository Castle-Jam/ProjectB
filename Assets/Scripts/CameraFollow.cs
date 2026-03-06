using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public Vector3 cameraOffset;
    [SerializeField] public Transform playerPosition;
    Vector3 playerPos;
    

    void Start()
    {
        playerPos = playerPosition.position;
    }


    void Update()
    {
        playerPos = playerPosition.position;
        transform.position = playerPos + cameraOffset;
    }
}
