using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public Transform[] ButtonPositions;
    int currentTransform = 0;
    Stopwatch stopwatch = new Stopwatch();
    // Start is called before the first frame update
    void Start()
    {

        transform.position = ButtonPositions[currentTransform].position;
        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(stopwatch.ElapsedMilliseconds >= 250)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                if (currentTransform >= ButtonPositions.Length - 1)
                {
                    currentTransform = 0;
                }
                else
                {
                    currentTransform++;
                    
                }
                stopwatch.Restart();
                transform.position = ButtonPositions[currentTransform].position;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                if (currentTransform <= 0)
                {
                    currentTransform = ButtonPositions.Length - 1;
                }
                else
                {
                    currentTransform--;
                }
                stopwatch.Restart();
                transform.position = ButtonPositions[currentTransform].position;
            }
        }
        if (Input.GetButtonDown("Submit"))
        {
            ButtonPositions[currentTransform].gameObject.GetComponent<Button>().onClick.Invoke();
        }
        
        
    }
}
