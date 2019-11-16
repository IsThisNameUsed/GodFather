using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public GameObject followCam;
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    public GameObject player;

    public Vector2 cameraPos;
    public Vector2 drawPos;

    public float screenAspect;
    public float camHalfHeight;
    public float camHalfWidth;
    public float camWidth;

    void Start()
    {
        //screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));

        screenAspect = (float)Screen.width / (float)Screen.height;
        camHalfHeight = MainCamera.orthographicSize;
        camHalfWidth = screenAspect * camHalfHeight;

        camWidth = camHalfWidth * 2;
        Debug.Log(camWidth);

        objectWidth = player.transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = player.transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }
    // Use this for initialization
    void Update()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, MainCamera.transform.position.z));
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x + camWidth - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;

        drawPos = viewPos;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //OnDrawGizmos();
    }

    /*public void OnDrawGizmos()
    {
        Vector3 drawPos = new Vector3 (followCam.transform.position.x, followCam.transform.position.y, followCam.transform.position.z);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(drawPos, 1);

    }*/
}
