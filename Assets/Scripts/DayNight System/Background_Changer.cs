using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Changer : MonoBehaviour
{
    public bool isNight;
    public Sprite dayBackground1;
    public Sprite dayBackground2;
    public Sprite nightBackground1;
    public Sprite nightBackground2;

    private void Update()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Background 1"))
        {
            if (isNight && go.GetComponent<SpriteRenderer>().sprite != nightBackground1)
                go.GetComponent<SpriteRenderer>().sprite = nightBackground1;
            else if (!isNight && go.GetComponent<SpriteRenderer>().sprite != dayBackground1)
                go.GetComponent<SpriteRenderer>().sprite = dayBackground1;
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Background 2"))
        {
            if (isNight && go.GetComponent<SpriteRenderer>().sprite != nightBackground2)
                go.GetComponent<SpriteRenderer>().sprite = nightBackground2;
            else if (!isNight && go.GetComponent<SpriteRenderer>().sprite != dayBackground2)
                go.GetComponent<SpriteRenderer>().sprite = dayBackground2;
        }
    }
}
