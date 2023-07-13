using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // 적 프리팹
    public GameObject StageClear;   // 게임 클리어 팝업입니다.
    public float spawnDelay = 0.5f;   // 스폰 딜레이

    public bool isGameClear = false;        // 게임 클리어 여부를 체크합니다. (true = 클리어, false = 클리어x)
    public int killCount = 0;              // 잡은 적의 마릿수를 체크합니다.
    int stageClear = 3;             // 잡아야하는 적의 마릿수를 나타냅니다.

    private void Start() { StartCoroutine(SpawnEnemy()); }
    private IEnumerator SpawnEnemy()
    {
        while (isGameClear)
        {
            // delay 후 적 생성
            yield return new WaitForSeconds(spawnDelay);

            // 적 생성
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            // 적의 체력이 0이 되면 다음 적 스폰
            Enemy enemyHealth = enemy.GetComponent<Enemy>();
            //FindObjectOfType<Player>().enemy = enemyHealth;

            // 적의 체력이 0이하 되면 다음 적 스폰
            while (enemyHealth.curHp > 0) { yield return null; }

            Destroy(enemy); // 체력이 0이 된 적 Destroy
            killCount++;    // 잡은 적의 마릿수 1증가

            // 잡은 적의 마릿수가 잡아야하는 적의 마릿수와 같다면 isGameOver를 false로 만들어줍니다.
            if (killCount == stageClear)
            {
                isGameClear = true;
                StageClear.SetActive(true);

                Time.timeScale = 0;
            }
        }
    }
}
