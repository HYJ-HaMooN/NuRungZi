using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameBtnManager : MonoBehaviour
{
    public Text atkCount;       // 어택버튼의 Max 카운트를 인게임에서 보여줄 수 있는 Text입니다. (임시코드입니다. 추후 변경 가능)
    public GameObject Setting;

    int maxAttackCount;         // 어택버튼을 누를 Max 카운트 수 입니다.
    int numOfCount;            // 카운트가 넘어간 횟수입니다.
    
    public bool isPause = false;       // 게임 일시정지를 체크해줍니다

    Player playerInfo;

    void Start()
    {
        maxAttackCount = 1;
        numOfCount = 1;

        playerInfo = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (isPause == true)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1;
    }

    // 공격버튼에 관련된 코드입니다.
    public void AttackButton()  // 공격버튼에 관련된 코드입니다. --HYJ0712  maxAttackCount가 1일때 바로 공격이 날아가게되는 부분수정
    {
        if (!isPause)
        {
            atkCount.text = maxAttackCount.ToString(); //UI적 표시
            maxAttackCount--; // (1) 0... 버튼을 누르는 횟수만큼 감소

            if (maxAttackCount == 0) //만약 카운트가 ( 1 -> 0 ) 에 다다르면
            {
                numOfCount++; // (1) 2 3 4.. 공격을 위해 버튼을 눌러야 하는 횟수 증가
                maxAttackCount += numOfCount; // 다음 총공격 횟수를 저장
                playerInfo.Attack(); // bullet발사      
            }
        }
    }

    // 공격횟수를 1로 초기화 시키는 버튼에 관련된 코드입니다.
    public void ResetButton()
    {
        if (MoneyManager.starCoin >= 500)
        {
            if (!isPause)
            {
                // 모든 수치 초기화
                maxAttackCount = 1;
                numOfCount = 1;
                atkCount.text = maxAttackCount.ToString();

                MoneyManager.starCoin -= 500;
            }
        }
    }





    // 공격횟수를 1로 초기화 시키는 버튼에 관련된 코드입니다.
    public void BMButton()
    {
        if (MoneyManager.starCoin > 500)
        {
            if (!isPause)
            {
                // 모든 수치 초기화
                maxAttackCount = 1;
                numOfCount = 1;
                atkCount.text = maxAttackCount.ToString();

                MoneyManager.starCoin -= 500;
            }
        }
    }

    public void SettingButton()
    {
        Setting.SetActive(true);
        isPause = true;
    }

    public void SettingExitButton()
    {
        Setting.SetActive(false);
        isPause = false;
    }
    

    public void GotoScene()
    {
        SceneManager.LoadScene("Stage");
    }

    public void ReStart()
    {
        SceneManager.LoadScene("PlayScene_JW");
    }

    public void TestStarCoinPlus()  // 테스트용 StarCoin(과금머니) 충전입니다.
    {
        MoneyManager.starCoin += 100000;
    }
}
