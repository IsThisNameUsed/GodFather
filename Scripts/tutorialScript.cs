using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    public bool isPaused;
    public GameObject[] opponents;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "TutoCol")
        {
            col.gameObject.SetActive(false);
            //Dialog
        }
    }
}
