using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wizard_Attack : MonoBehaviour
{
    public bool isNight = false;
    public GameObject wizardProjectile;
    public LayerMask townHallLayer;
    public Canvas upgradeCanvas;
    public TextMeshProUGUI damageUpgradeText;
    public TextMeshProUGUI cooldownUpgradeText;
    public TextMeshProUGUI amountUpgradeText;
    public TextMeshProUGUI passingUpgradeText;

    [Header("Stats")]
    public int speed = 10;
    public int damage = 25;
    public float cooldown = 1;
    public int amount = 1;
    public int passing = 1;

    private float attackTime = 0;
    private int damageUpgradePrice = 5;
    private int cooldownUpgradePrice = 5;
    private int amountUpgradePrice = 10;
    private int passingUpgradePrice = 10;

    private void Start()
    {
        damageUpgradeText.text = "Damage: " + damageUpgradePrice + " Woods";
        cooldownUpgradeText.text = "Cooldown: " + cooldownUpgradePrice + " Woods";
        amountUpgradeText.text = "Amount: " + amountUpgradePrice + " Woods";
        passingUpgradeText.text = "Pierce: " + passingUpgradePrice + " Woods";
    }

    private void Update()
    {
        if (Physics2D.OverlapCircleAll(transform.position, 2f, townHallLayer).Length == 0 || isNight)
        {
            upgradeCanvas.enabled = false;
        }
        else
            upgradeCanvas.enabled = true;

        if (Input.GetKey(KeyCode.Q) && isNight && Time.time > attackTime)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject projectile = Instantiate(wizardProjectile, transform.position + new Vector3(0.75f * transform.localScale.x, -0.5f, 0), Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * transform.localScale.x, 0);
            attackTime = Time.time + cooldown;
            yield return new WaitForSeconds(0.15f);
        }
    }

    public void IncreaseDamage()
    {
        if (GetComponent<Player_Resources>().wood >= damageUpgradePrice)
        {
            damage += 25;
            GetComponent<Player_Resources>().DecreaseWood(damageUpgradePrice);
            damageUpgradePrice *= 2;
            damageUpgradeText.text = "Damage: " + damageUpgradePrice + " Woods";
            Debug.Log("Upgraded Weapon");
        }
        else
            Debug.Log("Not Enough Wood");
    }

    public void DecreaseCooldown()
    {
        if (GetComponent<Player_Resources>().wood >= cooldownUpgradePrice)
        {
            cooldown /= 1.5f;
            GetComponent<Player_Resources>().DecreaseWood(cooldownUpgradePrice);
            cooldownUpgradePrice *= 2;
            cooldownUpgradeText.text = "Cooldown: " + cooldownUpgradePrice + " Woods";
            Debug.Log("Upgraded Weapon");
        }
        else
            Debug.Log("Not Enough Wood");
    }

    public void IncreaseAmount()
    {
        if (GetComponent<Player_Resources>().wood >= amountUpgradePrice)
        {
            amount++;
            GetComponent<Player_Resources>().DecreaseWood(amountUpgradePrice);
            amountUpgradePrice *= 2;
            amountUpgradeText.text = "Amount: " + amountUpgradePrice + " Woods";
            Debug.Log("Upgraded Weapon");
        }
        else
            Debug.Log("Not Enough Wood");
    }

    public void IncreasePassing()
    {
        if (GetComponent<Player_Resources>().wood >= passingUpgradePrice)
        {
            passing++;
            GetComponent<Player_Resources>().DecreaseWood(passingUpgradePrice);
            passingUpgradePrice *= 2;
            passingUpgradeText.text = "Pierce: " + passingUpgradePrice + " Woods";
            Debug.Log("Upgraded Weapon");
        }
        else
            Debug.Log("Not Enough Wood");
    }
}
