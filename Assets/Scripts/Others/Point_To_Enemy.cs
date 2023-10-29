using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point_To_Enemy : MonoBehaviour
{
    public LayerMask enemyLayer;
    public GameObject leftExclamation;
    public GameObject rightExclamation;

    private int left = 0;
    private int right = 0;

    bool inMap;

    private void Update()
    {
        if (Physics2D.OverlapCircleAll(new Vector2(0, 0), 24f, enemyLayer).Length != 0)
            inMap = true;

        if (inMap)
        {
            foreach (Collider2D col in Physics2D.OverlapCircleAll(new Vector2(0, 0), 24f, enemyLayer))
            {
                if (col.gameObject.transform.position.x < transform.position.x - 11f)
                    left++;
                else if (col.gameObject.transform.position.x > transform.position.x + 11f)
                    right++;
            }
        }

        if (left > 0)
            leftExclamation.GetComponent<Image>().enabled = true;
        else
            leftExclamation.GetComponent<Image>().enabled = false;

        if (right > 0)
            rightExclamation.GetComponent<Image>().enabled = true;
        else
            rightExclamation.GetComponent<Image>().enabled = false;

        left = 0;
        right = 0;
    }
}
