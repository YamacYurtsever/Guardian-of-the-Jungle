using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Properties : MonoBehaviour
{
    public int woodCount;
    public int seedCount = 1;
    public bool treeInteracted = false;
    public GameObject bark;
    public GameObject tip;
    public Animator animator;

    private int barkNum;
    private Vector3 barkPos;

    private void Start()
    {
        barkPos = transform.position + new Vector3(0, 1f, 0);
        barkNum = Random.Range(1, 5);
        woodCount = barkNum + 2;

        for (int i = 0; i < barkNum; i++)
        {
            GameObject newBark = Instantiate(bark, barkPos, Quaternion.identity);
            newBark.transform.parent = gameObject.transform;
            barkPos = newBark.transform.position + new Vector3(0, 1, 0);
        }
        GameObject newTip = Instantiate(tip, barkPos + new Vector3(0, 1, 0), Quaternion.identity);
        newTip.transform.parent = gameObject.transform;
        newTip.transform.SetAsFirstSibling();
        animator = newTip.GetComponent<Animator>();
    }
}
