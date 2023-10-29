using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayNight : MonoBehaviour
{
    [System.Serializable]
    public struct enemy
    {
        public GameObject[] night1EnemyTypes;
        public int[] night1EnemyNumbers;
        public int direction1;
        public GameObject[] night2EnemyTypes;
        public int[] night2EnemyNumbers;
        public int direction2;
        public GameObject[] night3EnemyTypes;
        public int[] night3EnemyNumbers;
        public int direction3;
        public GameObject[] night4EnemyTypes;
        public int[] night4EnemyNumbers;
        public int direction4;
        public GameObject[] night5EnemyTypes;
        public int[] night5EnemyNumbers;
        public int direction5;
    }

    public int nightNumber = 1;
    public int dayNumber = 1;
    public enemy enemies;
    public Background_Changer bc;
    public SceneLoader sl;
    public GameObject treeHolder;
    public GameObject seedHolder;
    public Button dayToNightButton;
    public TextMeshProUGUI dayNightMessages;

    private GameObject player;
    private Enemy_Spawner enemySpawner;
    private Town_Hall_Health_System townHallHealthSystem;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemySpawner = GameObject.FindGameObjectWithTag("Enemy Spawner").GetComponent<Enemy_Spawner>();
        townHallHealthSystem = GameObject.FindGameObjectWithTag("Town Hall").GetComponent<Town_Hall_Health_System>();
        DayStart();
    }

    public void DayStart()
    {
        //increase record
        GameObject.FindGameObjectWithTag("Nights Survived").GetComponent<Nights_Survived>().nightsSurvived = nightNumber - 1;
        dayToNightButton.interactable = true;

        //day message
        StartCoroutine(DayNightMessage("Day " + dayNumber));

        //change Background
        bc.isNight = false;

        //deactivate wizard attack
        player.GetComponent<Wizard_Attack>().isNight = false;

        //activate farm system
        player.GetComponent<Player_Tree_System>().enabled = true;
        for (int i = 0; i < treeHolder.transform.childCount; i++)
        {
            treeHolder.transform.GetChild(i).GetComponent<Tree_System>().enabled = true;
        }

        //reset ability to harvest seeds from each tree
        for (int i = 0; i < treeHolder.transform.childCount; i++)
        {
            treeHolder.transform.GetChild(i).GetComponent<Tree_Properties>().treeInteracted = false;
            treeHolder.transform.GetChild(i).GetComponent<Tree_Properties>().animator.SetBool("harvested", false);
        }

        //grow each seed by one round
        for (int i = 0; i < seedHolder.transform.childCount; i++)
        {
            seedHolder.transform.GetChild(i).GetComponent<SeedGrow>().GrowSeedByRounds();
        }

        //refill Town Hall Health
        townHallHealthSystem.IncreaseToFull();
    }

    public void NightStart()
    {
        //night message
        StartCoroutine(DayNightMessage("Night " + nightNumber));

        //change background
        bc.isNight = true;

        //activate wizard attack
        player.GetComponent<Wizard_Attack>().isNight = true;

        //deactivate farm system
        player.GetComponent<Player_Tree_System>().enabled = false;
        for (int i = 0; i < treeHolder.transform.childCount; i++)
        {
            treeHolder.transform.GetChild(i).GetComponent<Tree_System>().enabled = false;
        }

        //spawn enemies
        switch (nightNumber)
        {
            case 1:
                enemySpawner.StartSpawnEnemies(enemies.night1EnemyTypes, enemies.night1EnemyNumbers, enemies.direction1);
                break;
            case 2:
                enemySpawner.StartSpawnEnemies(enemies.night2EnemyTypes, enemies.night2EnemyNumbers, enemies.direction2);
                break;
            case 3:
                enemySpawner.StartSpawnEnemies(enemies.night3EnemyTypes, enemies.night3EnemyNumbers, enemies.direction3);
                break;
            case 4:
                enemySpawner.StartSpawnEnemies(enemies.night4EnemyTypes, enemies.night4EnemyNumbers, enemies.direction4);
                break;
            case 5:
                enemySpawner.StartSpawnEnemies(enemies.night5EnemyTypes, enemies.night5EnemyNumbers, enemies.direction5);
                break;
        }
    }

    //start wave when the button is pressed
    public void OnDayToNightButton()
    {
        if (dayNumber == nightNumber)
        {
            dayNumber++;
            dayToNightButton.interactable = false;
            NightStart();
        }
    }

    //fade in fade out
    IEnumerator DayNightMessage(string text)
    {
        dayNightMessages.enabled = true;
        dayNightMessages.text = text;

        for (float i = 0; i < 1; i += 0.01f)
        {
            dayNightMessages.color = new Color(dayNightMessages.color.r, dayNightMessages.color.g, dayNightMessages.color.b, i);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1f);

        for (float i = 1; i > 0; i -= 0.01f)
        {
            dayNightMessages.color = new Color(dayNightMessages.color.r, dayNightMessages.color.g, dayNightMessages.color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
    }
}