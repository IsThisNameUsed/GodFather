using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StringDisplayer : MonoBehaviour
{
    public bool isReady = true;

    public IEnumerator displayString(char[] chars, Text text)
    {
        isReady = false;
        for (int i = 0; i < chars.Length; i++)
        {
            text.text = text.text + chars[i];
            yield return new WaitForSecondsRealtime(0.02f);
        }
        isReady = true;
    }

    public void Start()
    {
    }

    public void Display(string String, Text text)
    {
        char[] chars = String.ToCharArray();
        StartCoroutine(displayString(chars, text));
    }

    public void stopDisplay()
    {
        StopAllCoroutines();
    }

    public void clearString(Text text)
    {
        text.text = "";
    }
}