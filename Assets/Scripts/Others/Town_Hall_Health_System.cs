using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Town_Hall_Health_System : MonoBehaviour
{
    public float maxHealth = 100;
    public GameObject healthBar;
    public SceneLoader sceneLoader;

    private float currentHealth;

    private void Start()
    {
        IncreaseToFull();
        healthBar.GetComponent<Slider>().maxValue = maxHealth;
        healthBar.GetComponent<Slider>().value = maxHealth;
    }

    public void DecreaseHealth(float damage)
    {
        currentHealth -= damage;
        healthBar.GetComponent<Slider>().value = currentHealth;
        if (currentHealth <= 0)
            sceneLoader.LoadGameOverScene();
    }

    public void IncreaseToFull()
    {
        currentHealth = maxHealth;
        healthBar.GetComponent<Slider>().value = currentHealth;
    }
}
