using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nights_Survived : MonoBehaviour
{
    public int nightsSurvived;

    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
