using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;  // �� ������
    public float spawnDelay = 1f;   // ���� ������
    
    bool isGameClear = true;
    int killCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (isGameClear)
        {
            yield return new WaitForSeconds(spawnDelay);

            // �� ����
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            // ���� ü���� 0�� �Ǹ� ���� �� ����
            Enemy enemyHealth = enemy.GetComponent<Enemy>();
            FindObjectOfType<Player>().enemy = enemyHealth;

            while (enemyHealth.maxHp > 0)
            {
                yield return null;
            }

            // ü���� 0�� �� �� ����
            Destroy(enemy);
            killCount++;

            if (killCount > 3)
            {
                isGameClear= false;
            }
        }
    }

    /* public GameObject[] enemy = new GameObject[3];    // �׽�Ʈ

     int index = 0;

     void Start()
     {
         Instantiate(enemy[0]);
     }

     void Update()
     {
         if (Time.deltaTime==1000000f)
         {
             index++;
             Instantiate(enemy[index]);
         }
     }*/
}
