using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Resources : MonoBehaviour
{
    public int wood = 0;
    public int seed = 0;
    public TextMeshProUGUI woodAmount;
    public TextMeshProUGUI seedAmount;

    public void IncreaseWood(int wood_amount)
    {
        wood += wood_amount;
        woodAmount.text = wood.ToString();
    }
    public void DecreaseWood(int wood_amount)
    {
        wood -= wood_amount;
        woodAmount.text = wood.ToString();
    }

    public void IncreaseSeed(int seed_amount)
    {
        seed += seed_amount;
        seedAmount.text = seed.ToString();
    }
    public void DecreaseSeed(int seed_amount)
    {
        seed -= seed_amount;
        seedAmount.text = seed.ToString();
    }
}
