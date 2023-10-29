using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Spawner : MonoBehaviour
{
    public int treeAmount;
    public GameObject treeRoot;
    public LayerMask fullLayer;
    public GameObject treeHolder;

    private int treePos;

    private void Start()
    {
        int i = 0;
        while (i < treeAmount)
        {
            treePos = Random.Range(-15, 15);
            Collider2D[] cols = Physics2D.OverlapCircleAll(new Vector2(treePos, -0.5f), 0.5f, fullLayer);
            if (cols.Length == 0)
            {
                GameObject treeRootObject = Instantiate(treeRoot, new Vector3(treePos, -0.5f, 0), Quaternion.identity);
                treeRootObject.transform.parent = treeHolder.transform;
                i++;
            }
        }
    }
}
