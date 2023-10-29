using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tree_System : MonoBehaviour
{
    public GameObject originalSeed;
    public GameObject seedHolder;
    public LayerMask seedLayer;
    public LayerMask treeLayer;

    private GameObject treeHolder;
    private Collider2D playerCol;
    private Player_Resources playerRes;

    private void Start()
    {
        playerCol = GetComponent<Collider2D>();
        playerRes = GetComponent<Player_Resources>();
        treeHolder = GameObject.FindGameObjectWithTag("Tree Holder");
    }

    private void Update()
    {
        if (!playerCol.IsTouchingLayers(treeLayer))
        {
            //plant seed
            if (Input.GetKeyDown(KeyCode.F) && !playerCol.IsTouchingLayers(seedLayer) && playerRes.seed > 0)
            {
                playerRes.DecreaseSeed(1);
                PlantSeed();
            }
        }
    }

    private void PlantSeed()
    {
        GameObject seed = Instantiate(originalSeed);
        seed.transform.position = transform.position - new Vector3(0, 0.5f, 0);
        seed.transform.parent = seedHolder.transform;
        seed.GetComponent<SeedGrow>().treeHolder = treeHolder;
    }
}
