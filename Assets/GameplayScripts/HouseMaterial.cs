using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HouseMaterial : MonoBehaviour
{

    List<GameObject> buildBlocks1 = new List<GameObject>();
    List<GameObject> buildBlocks2 = new List<GameObject>();
    List<GameObject> buildBlocks3 = new List<GameObject>();
    List<GameObject> buildBlocks4 = new List<GameObject>();
    public Image[] images;
    public Sprite[] sprites;
    public Sprite ExplosionSprite;
    public Image destructButton;
    public TMP_Text[] texts;
    public string[] posOpts;
    public Transform Selector;
    public Transform[] selections;
    int curSel = 0;
    int selectionsPossible = 3;
    Stopwatch sw = new Stopwatch();
    bool awaitingDestruct = false;
    public MatGroup[] MatGroups;
    int curOpt = 0;
    public GameObject Boulder;
    public AudioSource boulderSFX;
    bool bsfxplayed = false;
    [System.Serializable]
    public struct MatGroup
    {
        public Material[] mat;
       
    }

    
    void Start()
    {
        sw.Start();
        destructButton.gameObject.SetActive(false);
        Selector.position = selections[curSel].position;
        int mats = transform.childCount;
        for (int i = 0; i < mats; i++)
        {
            Transform matTr = transform.GetChild(i);
            switch (int.Parse(matTr.name))
            {
                case 1:
                    GetBuildingBlocks(matTr, buildBlocks1);
                    break;
                case 2:
                    GetBuildingBlocks(matTr, buildBlocks2);
                    break;
                case 3:
                    GetBuildingBlocks(matTr, buildBlocks3);
                    break;
                case 4:
                    GetBuildingBlocks(matTr, buildBlocks4);
                    break;

            }
            
        }
        ShowOptions(curOpt);
        
    }
    void GetBuildingBlocks(Transform matTr, List<GameObject> blockList)
    {
        for (int j = 0; j < matTr.childCount; j++)
        {
            blockList.Add(matTr.GetChild(j).gameObject);
        }
    }
    void AssignMat(List<GameObject> blockList, Material mat)
    {
        foreach (GameObject block in blockList)
        {
            block.GetComponent<MeshRenderer>().material = mat;
        }
    }
    void Destruct(List<GameObject> blockList)
    {
        foreach (GameObject block in blockList)
        {
            block.AddComponent<Rigidbody>();
        }
    }
    public void ChooseButton(int choice)
    {
        Choose(choice, true);
    }
    public void Choose(int choice, bool confirm)
    {
       switch (curOpt)
        {
            case 0:
                AssignMat(buildBlocks1, MatGroups[curOpt].mat[choice]);
                break;
            case 1:
                AssignMat(buildBlocks2, MatGroups[curOpt].mat[choice]);
                break;
            case 2:
                AssignMat(buildBlocks3, MatGroups[curOpt].mat[choice]);
                break;
            case 3:
                AssignMat(buildBlocks4, MatGroups[curOpt].mat[choice]);
                break;
        }
        if (confirm)
        {
            curOpt++;
            if(curOpt == 4)
            {
                Selector.gameObject.SetActive(false);
                images[0].gameObject.SetActive(false);
                images[2].gameObject.SetActive(false);
                foreach (TMP_Text t in texts)
                {

                    t.text = "";
                }
                texts[1].text = "Натисни       , за да разрушиш";
                images[1].sprite = ExplosionSprite;
                destructButton.gameObject.SetActive(true);
                awaitingDestruct = true;
            }
            ShowOptions(curOpt);
        }
        
    }
    // Update is called once per frame
    void ShowOptions(int opt)
    {
        
        for(int i=selectionsPossible*opt; i<selectionsPossible+(opt*selectionsPossible); i+=selectionsPossible)
        {
            for(int j=0; j<selectionsPossible; j++)
            {
                images[j].sprite = sprites[i+j];
                texts[j].text = posOpts[i+j];
            }
        }
        Choose(curSel, false);



    }
    async void Update()
    {
        if(sw.ElapsedMilliseconds >= 350)
        {
            if(Input.GetAxis("Horizontal") > 0.1f)
            {
                if(curSel < selectionsPossible-1)
                {
                    curSel++;
                    Selector.position = selections[curSel].position;
                    Choose(curSel, false);
                    sw.Restart();
                }
                
            }
            else if(Input.GetAxis("Horizontal") < -0.1f)
            {
                if(curSel > 0) 
                {
                    curSel--;
                    Selector.position = selections[curSel].position;
                    Choose(curSel, false);
                    sw.Restart();

                }
            }

        }
        if (Input.GetButtonDown("Submit"))
        {
            if(awaitingDestruct == false) 
            {
                selections[curSel].GetComponent<Button>().onClick.Invoke();
            }
            else
            {
                Boulder.AddComponent<Rigidbody>();
                
            }
            
        }
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.name == "Boulder")
        {
            if(bsfxplayed == false)
            {
                boulderSFX.Play();
            }
            bsfxplayed = true;
            
            Destruct(buildBlocks1);
            Destruct(buildBlocks2);
            Destruct(buildBlocks3);
            Destruct(buildBlocks4);
        }
    }
}
