using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // �� ������
    public GameObject StageClear;   // ���� Ŭ���� �˾��Դϴ�.
    public float spawnDelay = 0.5f;   // ���� ������

    bool isGameClear = true;        // ���� Ŭ���� ���θ� üũ�մϴ�. (true = Ŭ����x, false = Ŭ����)
    public int killCount = 0;              // ���� ���� �������� üũ�մϴ�.
    int stageClear = 3;             // ��ƾ��ϴ� ���� �������� ��Ÿ���ϴ�.

    private void Start() { StartCoroutine(SpawnEnemy()); }
    private IEnumerator SpawnEnemy()
    {
        while (isGameClear)
        {
            // delay �� �� ����
            yield return new WaitForSeconds(spawnDelay);

            // �� ����
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            // ���� ü���� 0�� �Ǹ� ���� �� ����
            Enemy enemyHealth = enemy.GetComponent<Enemy>();
            //FindObjectOfType<Player>().enemy = enemyHealth;

            // ���� ü���� 0���� �Ǹ� ���� �� ����
            while (enemyHealth.curHp > 0) { yield return null; }

            Destroy(enemy); // ü���� 0�� �� �� Destroy
            killCount++;    // ���� ���� ������ 1����

            // ���� ���� �������� ��ƾ��ϴ� ���� �������� ���ٸ� isGameOver�� false�� ������ݴϴ�.
            if (killCount == stageClear)
            {
                isGameClear = false;
                StageClear.SetActive(true);

                Time.timeScale = 0;
            }
        }
    }
}
