using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudySingleton : Singleton<StudySingleton>
{
    public Text text = null;

    public void Awake()
    {
        text = GameObject.Find("Text").GetComponent<Text>();
    }

    public void OnShow(string str)
    {
        if (text == null)
            return;

        text.text = str;
    }
}
