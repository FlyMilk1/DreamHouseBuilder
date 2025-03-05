using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButtonByInput : MonoBehaviour
{
    public string ButtonString;
    void Update()
    {
        if (Input.GetButtonDown(ButtonString))
        {
            gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
}
