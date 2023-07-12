using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;  // �� ������
    public float spawnDelay = 1f;   // ���� ������
    
    bool isGameClear = true;        // ���� Ŭ���� ���θ� üũ�մϴ�. (true = Ŭ����x, false = Ŭ����)
    int killCount = 0;              // ���� ���� �������� üũ�մϴ�.
    int stageClear = 3;             // ��ƾ��ϴ� ���� �������� ��Ÿ���ϴ�.

    private void Start()
    {
        StartCoroutine(SpawnEnemy());   // Enemy spawn �ڷ�ƾ
    }

    private IEnumerator SpawnEnemy()
    {
        while (isGameClear)                                 // ���� Ŭ���� ���°� �ƴ϶��
        {
            yield return new WaitForSeconds(spawnDelay);    // (��)���� �����̸�ŭ ���

            // �� ����
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            // ���� ü���� 0�� �Ǹ� ���� �� ����
            Enemy enemyHealth = enemy.GetComponent<Enemy>();
            FindObjectOfType<Player>().enemy = enemyHealth;

            while (enemyHealth.maxHp > 0)
            {
                yield return null;
            }

           
            Destroy(enemy); // ü���� 0�� �� �� Destroy

            killCount++;    // ���� ���� ������ 1����

            // ���� ���� �������� ��ƾ��ϴ� ���� �������� ���ٸ� isGameOver�� false�� ������ݴϴ�.
            if (killCount == stageClear)
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
