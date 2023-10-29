using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject enemyHolder;
    public DayNight dayNightSystem;
    public SceneLoader sl;
    
    public void StartSpawnEnemies(GameObject[] enemies, int[] enemyNumbers, int direction)
    {
        StartCoroutine(SpawnEnemies(enemies, enemyNumbers, direction));
    }

    IEnumerator SpawnEnemies(GameObject[] enemies, int[] enemyNumbers, int direction)
    {
        for(int a = 0; a < enemyNumbers.Length; a++)
        {
            for (int i = 0; i < enemyNumbers[a]; i++)
            {
                int newDirection = direction;
                if (direction == 0)
                    newDirection = Random.Range(0, 2) * 2 - 1;
                GameObject enemy = Instantiate(enemies[a], new Vector3(newDirection * 24, 0, 0), Quaternion.identity);
                enemy.transform.localScale = new Vector2(-1 * newDirection, enemy.transform.localScale.y);
                enemy.transform.parent = enemyHolder.transform;
                yield return new WaitForSeconds(0.75f);
            }
        }
        StartCoroutine(CheckIfEnemyDead());
    }

    IEnumerator CheckIfEnemyDead()
    {
        if(enemyHolder.transform.childCount == 0)
        {
            //if it is the last night end game
            if (dayNightSystem.nightNumber == 5)
                sl.LoadWinScene();

            //else go to next day
            foreach (GameObject projectile in GameObject.FindGameObjectsWithTag("Projectile"))
            {
                Destroy(projectile);
            }
            dayNightSystem.nightNumber = dayNightSystem.nightNumber + 1;
            dayNightSystem.DayStart();
            StopAllCoroutines();
        }
        yield return new WaitForSeconds(0.1f);
        yield return CheckIfEnemyDead();
    }
}
