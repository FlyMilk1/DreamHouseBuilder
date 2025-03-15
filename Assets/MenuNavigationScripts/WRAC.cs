using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WRAC : MonoBehaviour
{
    public Animator animator;
    
    void Start()
    {
        Invoke("animate", 2f);
        Invoke("Cont", 3f);
    }
    void animate()
    {
        animator.SetTrigger("anim");
    }
    private void Cont()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
