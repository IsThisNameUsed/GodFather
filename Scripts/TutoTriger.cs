using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoTriger : MonoBehaviour
{
    DialogSequences dialogSequences;
    public string dialogName;

    // Start is called before the first frame update
    void Start()
    {
        dialogSequences = GameObject.Find("GameManager").GetComponent<DialogSequences>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
            dialogSequences.LaunchDialogTuto(dialogName);
    }
}
