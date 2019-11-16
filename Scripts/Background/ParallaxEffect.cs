using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float scrollingSpeedX, scrollingSpeedY;
    [SerializeField] private Transform cameraTransform;
    private float LastCameraX;
    private float LastCameraY;

    private void Start()
    {
        LastCameraX = cameraTransform.position.x;
        LastCameraY = cameraTransform.position.y;
    }

    private void Update()
    {
        float deltaX = cameraTransform.position.x - LastCameraX;
        float deltaY = cameraTransform.position.y - LastCameraY;
        transform.position += new Vector3(deltaX * scrollingSpeedX, deltaY * scrollingSpeedY);

        LastCameraX = cameraTransform.position.x;
        LastCameraY = cameraTransform.position.y;
    }
}
