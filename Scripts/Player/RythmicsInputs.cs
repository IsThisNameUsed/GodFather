using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmicsInputs : MonoBehaviour
{
    [Header("Fréquence des trois rythmes en secondes")]
    [Range(0,1)]
    public float rythm1;
    [Range(0,1)]
    public float rythm2;
    [Range(0,1)]
    public float rythm3;

    [Header("Imprécision autorisée pour chaque rythme, en seconde")]
    [Range(0, 0.5f)]
    public float imprecision1;
    [Range(0, 0.5f)]
    public float imprecision2;
    [Range(0, 0.5f)]
    public float imprecision3;

    public GameObject ShowTempo;
    private SpriteRenderer ShowTempoSprite;
    private PlayerController playerController;
    private float inputTime1;
    private float inputTime2;
    private float inputTime3;
    private int inputNumber;

    [Header("tempo we show to the player")]
    public float tempo;
    private float count;

    IEnumerator ChangeColor()
    {
        ShowTempoSprite.color = Color.blue;
        yield return new WaitForSeconds(0.1f);
        ShowTempoSprite.color = Color.white;
    }
    void Start()
    {
        ShowTempoSprite = ShowTempo.GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
        inputNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Décompte pour tempo
        count = count - Time.deltaTime;
        if (count == 0 || count < 0)
        {
            count = tempo;
            StartCoroutine("ChangeColor");
        }


        if (Input.GetButtonDown("Fire"))
        {
            switch(inputNumber)
            {
                case 1:
                    inputTime1 = Time.time;
                    inputNumber = 2;
                    break;
                case 2:
                    inputTime2 = Time.time;
                    inputNumber = 1;
                    CalculateShotRythm();
                    break;
                /*case 3:
                    inputTime3 = Time.time;
                    inputNumber = 1;
                    break;*/
            }
        }
    }

   private void CalculateShotRythm()
    {
        int rythmInput1 = 0;
        int rythmInput2 = 0;

        float duration1 = inputTime2 - inputTime1;
        //float duration2 = inputTime3 - inputTime2;

        if (duration1 > rythm1 - imprecision1/2 && duration1 < rythm1 + imprecision1/2)
            rythmInput1 = 1;
        else if (duration1 > rythm2 - imprecision2/2 && duration1 < rythm2 + imprecision2/2)
            rythmInput1 = 2;
        else if (duration1 > rythm3 - imprecision3 / 2 && duration1 < rythm3 + imprecision3 / 2)
            rythmInput1 = 3;
        else rythmInput1 = 0;

        /*if (duration2 > rythm1 - imprecision1 / 2 && duration2 < rythm1 + imprecision1 / 2)
            rythmInput2 = 1;
        else if (duration2 > rythm2 - imprecision2 / 2 && duration2 < rythm2 + imprecision2 / 2)
            rythmInput2 = 2;
        else if (duration2 > rythm3 - imprecision3 / 2 && duration2 < rythm3 + imprecision3 / 2)
            rythmInput2 = 3;
        else rythmInput2 = 0;*/
        Debug.Log(rythmInput1);
        playerController.ModifyColor(rythmInput1);
       /* if (rythmInput1 !=0 && rythmInput1 == rythmInput2)
            playerController.ModifyColor(rythmInput1);
        else playerController.ModifyColor(0);*/

    }
}
