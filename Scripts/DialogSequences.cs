using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSequences : MonoBehaviour
{
    private DialogDatabase dialogDatabase;
    private StringDisplayer stringDisplayer;
    private GameObject gameManager;
    public Image portrait;
    public Text dialogText;
    public Image dialogPanel;
    public Image portraitCadre;
    public Image texteCadre;

    IEnumerator DialogBoss()
    {
        stringDisplayer.Display(dialogDatabase.ReturnInfos("dialog1"), dialogText);
        portrait.sprite = Resources.Load<Sprite>("LucySourire");
        while (stringDisplayer.isReady == false)
            yield return new WaitForSecondsRealtime(1);
        yield return new WaitForSecondsRealtime(0.5f);
        stringDisplayer.clearString(dialogText);

        stringDisplayer.Display(dialogDatabase.ReturnInfos("dialog2"), dialogText);
        portrait.sprite = Resources.Load<Sprite>("LucySurprise");
        while (stringDisplayer.isReady == false)
            yield return new WaitForSecondsRealtime(1);
        stringDisplayer.clearString(dialogText);

        stringDisplayer.Display(dialogDatabase.ReturnInfos("dialog3"), dialogText);
        portrait.sprite = Resources.Load<Sprite>("LucyEmbete");
        while (stringDisplayer.isReady == false)
            yield return new WaitForSecondsRealtime(1);
        stringDisplayer.clearString(dialogText);

        stringDisplayer.Display(dialogDatabase.ReturnInfos("dialog4"), dialogText);
        portrait.sprite = Resources.Load<Sprite>("LucyEmbete");
        while (stringDisplayer.isReady == false)
            yield return new WaitForSecondsRealtime(1);
        stringDisplayer.clearString(dialogText);

        stringDisplayer.Display(dialogDatabase.ReturnInfos("dialog5"), dialogText);
        portrait.sprite = Resources.Load<Sprite>("LucySourire");
        while (stringDisplayer.isReady == false)
            yield return new WaitForSecondsRealtime(1);
        stringDisplayer.clearString(dialogText);

        dialogPanel.enabled = false;
        portrait.enabled = false;
        dialogText.enabled = false;
        texteCadre.enabled = false;
        portraitCadre.enabled = false;
        stringDisplayer.clearString(dialogText);
        Time.timeScale = 1;
    }

    IEnumerator DialogTuto(string dialogName)
    {
        Debug.Log(dialogName);
        if (stringDisplayer.isReady == true)
        {
            portrait.sprite = Resources.Load<Sprite>("LucySourire");
            stringDisplayer.Display(dialogDatabase.ReturnInfos(dialogName), dialogText);
            while (stringDisplayer.isReady == false)
                yield return new WaitForSecondsRealtime(1);
            yield return new WaitForSecondsRealtime(0.5f);
            stringDisplayer.clearString(dialogText);
            dialogPanel.enabled = false;
            portrait.enabled = false;
            dialogText.enabled = false;
            texteCadre.enabled = false;
            portraitCadre.enabled = false;
        }
        
    }

    /*IEnumerator DialogTuto(string dialogName)
    {
        Time.timeScale = 0;
        portrait.sprite = Resources.Load<Sprite>("LucySourire");
        stringDisplayer.Display(dialogDatabase.ReturnInfos("dialogTuto1"), dialogText);
        while (stringDisplayer.isReady == false)
            yield return new WaitForSecondsRealtime(1);
        yield return new WaitForSecondsRealtime(0.5f);
        stringDisplayer.clearString(dialogText);
        Time.timeScale = 1;

        stringDisplayer.Display(dialogDatabase.ReturnInfos("dialogTuto2"), dialogText);
        while (stringDisplayer.isReady == false)
            yield return new WaitForSecondsRealtime(1);
        yield return new WaitForSecondsRealtime(0.5f);
        stringDisplayer.clearString(dialogText);

        stringDisplayer.Display(dialogDatabase.ReturnInfos("dialogTuto3"), dialogText);
        while (stringDisplayer.isReady == false)
            yield return new WaitForSecondsRealtime(1);
        yield return new WaitForSecondsRealtime(0.5f);
        stringDisplayer.clearString(dialogText);

        stringDisplayer.Display(dialogDatabase.ReturnInfos("dialogTuto4"), dialogText);
        while (stringDisplayer.isReady == false)
            yield return new WaitForSecondsRealtime(1);
        yield return new WaitForSecondsRealtime(0.5f);
        stringDisplayer.clearString(dialogText);

        stringDisplayer.Display(dialogDatabase.ReturnInfos("dialogTuto5"), dialogText);
        while (stringDisplayer.isReady == false)
            yield return new WaitForSecondsRealtime(1);
        yield return new WaitForSecondsRealtime(0.5f);
        stringDisplayer.clearString(dialogText);

        stringDisplayer.Display(dialogDatabase.ReturnInfos("dialogTuto6"), dialogText);
        while (stringDisplayer.isReady == false)
            yield return new WaitForSecondsRealtime(1);
        yield return new WaitForSecondsRealtime(0.5f);
        dialogPanel.enabled = false;
        portrait.enabled = false;
        dialogText.enabled = false;
        stringDisplayer.clearString(dialogText);
    }*/

    public void Start()
    {
        dialogPanel = GameObject.Find("DialogPanel").GetComponent<Image>();
        portrait = GameObject.Find("Portrait").GetComponent<Image>();
        dialogText = GameObject.Find("DialogText").GetComponent<Text>();
        portraitCadre = GameObject.Find("CadrePortrait").GetComponent<Image>();
        texteCadre = GameObject.Find("CadreTexte").GetComponent<Image>();
        dialogPanel.enabled = false;
        portrait.enabled = false;
        dialogText.enabled = false;
        portraitCadre.enabled = false;
        texteCadre.enabled = false;
        gameManager = GameObject.Find("GameManager");
        dialogDatabase = new DialogDatabase();
        stringDisplayer = gameManager.GetComponent<StringDisplayer>();
    }

    public void Update()
    {
        if (Input.GetKeyDown("d"))
            LaunchDialogBoss();
    }
    
    public void LaunchDialogBoss()
    {
        dialogPanel.enabled = true;
        portrait.enabled = true;
        dialogText.enabled = true;
        texteCadre.enabled = true;
        portraitCadre.enabled = true;
        Time.timeScale = 0;
        StartCoroutine(DialogBoss());
    }

    public void LaunchDialogTuto(string dialogName)
    {
        dialogPanel.enabled = true;
        portrait.enabled = true;
        dialogText.enabled = true;
        texteCadre.enabled = true;
        portraitCadre.enabled = true;
        StartCoroutine(DialogTuto(dialogName));
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Coucou je bouge");
        if (other.gameObject.CompareTag("bossCollid"))
        {
            LaunchDialogBoss();
        }
    }
}
