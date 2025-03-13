using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class VideoSettings : MonoBehaviour
{
    public TMP_Text text;
    public int curOpt=0;
    int maxOpt = 2;
    string[] bgsettings = {"Ниско", "Средно", "Високо"};
    public void ChangeDown()
    {
        
        
            if (curOpt <= 0)
            {
                curOpt = maxOpt;
            }
            else { curOpt--; }
            text.text = bgsettings[curOpt];
        
    }
    public void ChangeUp()
    {
        if (curOpt >= maxOpt)
        {
            curOpt = 0;
        }
        else
        { curOpt++; }
        text.text = bgsettings[curOpt];
    }
}
