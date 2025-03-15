using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeIconByJoystick : MonoBehaviour
{
    public Sprite spriteJoystick;
    public Sprite spritekeyboard;
    int cur = 0;
   
    void Update()
    {
        if(Input.GetJoystickNames().Length <= 0)
        {
           
            gameObject.GetComponent<Image>().sprite = spritekeyboard;
            
        }
        else if (cur == 0)
        {
           
            gameObject.GetComponent<Image>().sprite = spriteJoystick;
        }
    }
}
