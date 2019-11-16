using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingLaser : MonoBehaviour
{
    public GameObject start1;
    public GameObject start2;
    public GameObject start3;

    public GameObject goal1;
    public GameObject goal2;
    public GameObject goal3;

    public GameObject MastaSpalku;
    public GameObject MarkerSample;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p")) {
            StartCoroutine(LaserSingleton.MasterSpark(start1, goal1, MastaSpalku));
            LaserSingleton.raycastBegin = true;
        }

        if (Input.GetKeyDown("o")) {
            StartCoroutine(LaserSingleton.MasterSpark(start2, goal2, MastaSpalku));
            LaserSingleton.raycastBegin = true;
        }

        if (Input.GetKeyDown("i")) {
            StartCoroutine(LaserSingleton.MasterSpark(start3, goal3, MastaSpalku));
            LaserSingleton.raycastBegin = true;
        }

    }
}
