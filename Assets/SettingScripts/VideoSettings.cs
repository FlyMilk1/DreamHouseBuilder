using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class VideoSettings : MonoBehaviour
{
    public TMP_Text text;
    public int curOpt;
    int maxOpt = 2;
    string[] bgsettings = {"Ниско", "Средно", "Високо"};
    public void ChangeSet(int increment)
    {
        if (increment > 0)
        {
            if(curOpt >= maxOpt)
            {
                curOpt = 0;
            }
            else
            { curOpt++; }
        }
        else if (increment < 0) { }
        {
            if (curOpt <= 0)
            {
                curOpt = maxOpt;
            }
            else { curOpt--; }
        }
        text.text = bgsettings[curOpt];
    }
}
