using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if(!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
            {
                Cursor.visible = false;
            }
            else
            {
                Cursor.visible = true;
            }
        }
    }
}
