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
        if(Input.GetJoystickNames() != null && cur == 1)
        {
            gameObject.GetComponent<Image>().sprite = spriteJoystick;
        }
        else if (cur == 0)
        {
            gameObject.GetComponent<Image>().sprite = spritekeyboard;
        }
    }
}
