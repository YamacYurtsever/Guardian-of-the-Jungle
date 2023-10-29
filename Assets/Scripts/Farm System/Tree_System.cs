using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_System : MonoBehaviour
{
    public GameObject originalSeed;
    public GameObject cutTree;

    private GameObject player;
    private Collider2D playerCol;
    private Collider2D treeCol;
    private Animator playerAnimator;
    private Tree_Properties treeProps;
    private Player_Resources playerRes;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider2D>();
        playerAnimator = player.GetComponent<Animator>();
        playerRes = player.GetComponent<Player_Resources>();
        treeCol = GetComponent<Collider2D>();
        treeProps = GetComponent<Tree_Properties>();
    }

    private void Update()
    {
        if (treeCol.IsTouching(playerCol) && !treeProps.treeInteracted)
        {
            //get seed
            if(Input.GetKeyDown(KeyCode.F))
            {
                player.GetComponent<Player_Movement>().enabled = false;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                playerAnimator.SetTrigger("harvest");
                StartCoroutine(Harvest());
            }

            //get wood
            if (Input.GetKeyDown(KeyCode.G))
            {
                player.GetComponent<Player_Movement>().enabled = false;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                playerAnimator.SetTrigger("cut");
                StartCoroutine(Cut());
            }
        }
    }

    IEnumerator Harvest()
    {
        treeProps.treeInteracted = true;
        yield return new WaitForSeconds(0.5f);
        treeProps.animator.SetBool("harvested", true);
        player.GetComponent<Player_Movement>().enabled = true;
        playerRes.IncreaseSeed(treeProps.seedCount);
    }

    IEnumerator Cut()
    {
        treeProps.treeInteracted = true;
        yield return new WaitForSeconds(0.5f);
        playerRes.IncreaseWood(treeProps.woodCount);
        player.GetComponent<Player_Movement>().enabled = true;
        Instantiate(cutTree, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
