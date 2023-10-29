using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health_System : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void DecreaseHealth(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("hurt");
        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
