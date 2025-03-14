using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HouseMaterial : MonoBehaviour
{

    List<GameObject> buildBlocks1 = new List<GameObject>();
    List<GameObject> buildBlocks2 = new List<GameObject>();
    List<GameObject> buildBlocks3 = new List<GameObject>();
    List<GameObject> buildBlocks4 = new List<GameObject>();
    public Image[] images;
    public Sprite[] sprites;
    public TMP_Text[] texts;
    public string[] posOpts;
    public Transform Selector;
    public Transform[] selections;
    int curSel = 0;

    Stopwatch sw = new Stopwatch();

    public MatGroup[] MatGroups;
    int curOpt = 0;
    [System.Serializable]
    public struct MatGroup
    {
        public Material[] mat;
       
    }

    
    void Start()
    {
        sw.Start();
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
    public void Choose(int choice)
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
        curOpt++;
        ShowOptions(curOpt);
    }
    // Update is called once per frame
    void ShowOptions(int opt)
    {
        if(opt == 4)
        {

        }
        for(int i=3*opt; i<3+(opt*3); i+=3)
        {
            for(int j=0; j<3; j++)
            {
                images[j].sprite = sprites[i+j];
                texts[j].text = posOpts[i+j];
            }
        }
                
                
        
    }
    void Update()
    {
        if(sw)
    }
}
