using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScreen : MonoBehaviour
{
public CanvasGroup flashing; 
private bool flash = false;

    void Awake() {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        // flashing = CanvasGroup.FindObjectWithTag("Flash");
        flashing.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (flash) {
            flashing.alpha = flashing.alpha - Time.deltaTime;
            if (flashing.alpha <= 0) {
                flashing.alpha = 0;
                flash = false;
            }
        }
    }

    public void Flashbang () {
        flashing.alpha = 1;
        flash = true;
    }
}
