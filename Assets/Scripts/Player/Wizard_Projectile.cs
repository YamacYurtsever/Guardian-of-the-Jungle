using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Projectile : MonoBehaviour
{
    private int damage;
    private int passing;

    private void Start()
    {
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<Wizard_Attack>().damage;
        passing = GameObject.FindGameObjectWithTag("Player").GetComponent<Wizard_Attack>().passing;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy_Health_System>().DecreaseHealth(damage);
            if (passing == 1)
                Destroy(gameObject);
            else
                passing--;
        }
    }
}
