using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // �� ������
    public float spawnDelay = 1f;   // ���� ������

    bool isGameClear = false;
    public int killCount = 0, stageClear = 3;

    private void Start() { StartCoroutine(SpawnEnemy()); }
    private IEnumerator SpawnEnemy()
    {
        while (!isGameClear)
        {
            // delay �� �� ����
            yield return new WaitForSeconds(spawnDelay);
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // ���� ü���� 0���� �Ǹ� ���� �� ����
            while (FindObjectOfType<Enemy>().maxHp > 0) { yield return null; }

            if (killCount == stageClear)
            { isGameClear = true; SceneManager.LoadScene(1); }
        }
    }
}
