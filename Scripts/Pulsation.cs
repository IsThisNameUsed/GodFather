using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pulsation : MonoBehaviour
{

    // Grow parameters
    public float approachSpeed = 0.006f;
    public float growthBound = 0.1f;
    public float shrinkBound = 0.2f;
    private float currentRatio = 1;

    // The text object we're trying to manipulate
    public GameObject Vinyle;
    

    // And something to do the manipulating
    private Coroutine routine;
    private bool keepGoing = true;
    private bool closeEnough = false;

    // Attach the coroutine
    void Awake()
    {

        currentRatio = this.transform.localScale.x;
        // Then start the routine
        this.routine = StartCoroutine(this.Pulse());
    }

    IEnumerator Pulse()
    {
        // Run this indefinitely
        while (keepGoing)
        {
            // Get bigger for a few seconds
            while (this.currentRatio != this.growthBound)
            {
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, growthBound, approachSpeed);

                // Update our text element
                Vinyle.transform.localScale = Vector3.one * currentRatio; 
               

                yield return new WaitForEndOfFrame();
            }

            // Shrink for a few seconds
            while (this.currentRatio != this.shrinkBound)
            {
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, shrinkBound, approachSpeed);

                // Update our text element
                Vinyle.transform.localScale = Vector3.one * currentRatio;

                yield return new WaitForEndOfFrame();
            }
        }
    }

}
