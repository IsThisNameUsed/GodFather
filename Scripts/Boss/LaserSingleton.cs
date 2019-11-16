using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSingleton : MonoBehaviour
{

    public static LaserSingleton instance;

    private static GameObject MidMarker;
    public static GameObject startingMarker;
    public static GameObject goalingMarker;
    private static Vector2 memories;
    

    public static bool raycastBegin = false;
    public float speed = 1;
    private static bool laserScaling = false;

    public static GameObject newLaser;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this) {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (raycastBegin) {
            Debug.Log("Start the Ray");
            float step = speed * Time.deltaTime;
            Vector2 Arrive = goalingMarker.transform.position;
            startingMarker.transform.position = Vector2.MoveTowards(startingMarker.transform.position, Arrive, step);
            if (startingMarker.transform.position.x <= Arrive.x) {
                startingMarker.transform.position = Arrive;
                startingMarker.transform.position = memories;
                raycastBegin = false;
            }
        }

        if (laserScaling) {
            Debug.Log("Starting the Laser");
            if (newLaser != null) {
                float X = (goalingMarker.transform.position.x - startingMarker.transform.position.x) / 2;
                newLaser.transform.localScale += new Vector3(12,0,0);

                if (newLaser.transform.localScale.x >= 140) {
                    newLaser.transform.localScale = new Vector3 (140, newLaser.transform.localScale.y, 0);
                    newLaser.transform.localScale += new Vector3(0 , 7.5f, 0);

                    if (newLaser.transform.localScale.y >= 40) {
                        newLaser.transform.localScale = new Vector3(140, 40, 0);
                        StartCoroutine(EndSpellCard());
                        laserScaling = false;
                    }
                }
            }
            Debug.Log(newLaser);
        }
    }

    public static IEnumerator MasterSpark (GameObject startpoint , GameObject goalpoint, GameObject laser) {
        Debug.Log("Initiate Laser");
        startingMarker = startpoint;
        goalingMarker = goalpoint;
        memories = startingMarker.transform.position;
        Vector2 start = startpoint.transform.position;
        Vector2 goal = goalpoint.transform.position;
        Vector2 markerPoint = new Vector2();
        markerPoint.x = ((goal.x + start.x)/2);
        Debug.Log(goal.x);
        Debug.Log(start.x);
        Debug.Log((goal.x+start.x)/2);
        markerPoint.y = ((goal.y + start.y)/2);
        Debug.Log(goal.y);
        Debug.Log(start.y);
        Debug.Log((goal.y+start.y)/2);
        MidMarker = Instantiate(goalpoint, markerPoint, goalpoint.transform.rotation);
        yield return new WaitForSeconds(1.5f);
        newLaser = Instantiate(laser, MidMarker.transform.position, MidMarker.transform.rotation);
        laserScaling = true;
        yield break;
    }

    public static IEnumerator EndSpellCard() {
        Debug.Log("Destroy Laser");
        yield return new WaitForSeconds(2.0f);
        Destroy(MidMarker);
        Destroy(newLaser);
        Debug.Log(newLaser);
        yield break;
    }
}
