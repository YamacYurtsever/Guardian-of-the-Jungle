using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Petrol_Man_Projectile : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.gameObject.tag == "Town Hall")
        {
            collision.gameObject.GetComponent<Town_Hall_Health_System>().DecreaseHealth(damage);
            Destroy(gameObject);
        }
    }
}
