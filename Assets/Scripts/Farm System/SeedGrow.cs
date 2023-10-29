using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGrow : MonoBehaviour
{
    public GameObject treeRoot;
    public GameObject treeHolder;
    public Sprite oldSapling;

    private int seedDay = 0;
    public int growForTree = 2;

    public void GrowSeedByRounds()
    {
        seedDay++;

        if (seedDay == 1)
        {
            GetComponent<SpriteRenderer>().sprite = oldSapling;
        }
        else if(seedDay == 2)
        {
            //seed becomes a tree
            GameObject tree = Instantiate(treeRoot, new Vector3(0, -0.5f, 0), Quaternion.identity);
            tree.transform.parent = treeHolder.transform;
            tree.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
