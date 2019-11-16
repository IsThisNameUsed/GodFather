using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonQuit : MonoBehaviour
{
    public float Choice = 1;
    public GameObject Continue;
    public GameObject Quit;

    // Start is called before the first frame update
    void Start()
    {
        Choice = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            Choice +=1;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Choice -=1;
        }

        if (Choice == 0) {
            Choice = 2;
        }
        else if (Choice == 3) {
            Choice = 0;
        }


        if (Choice == 1) {
            Continue.GetComponent<Image>().color = new Color(255f,255f,255f, 1f);
            Quit.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.5f);
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) {
                this.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (Choice == 2) {
            Continue.GetComponent<Image>().color = new Color(255f,255f,255f, 0.5f);
            Quit.GetComponent<Image>().color = new Color(255f, 255f, 255f, 1);
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) {
                SceneManager.LoadScene("Menu");
            }
        }
    }
    
    public void onQuit() {
        
    }
}
