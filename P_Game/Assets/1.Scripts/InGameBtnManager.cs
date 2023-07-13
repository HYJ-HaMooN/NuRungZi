using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameBtnManager : MonoBehaviour
{
    public Text atkCount;       // ���ù�ư�� Max ī��Ʈ�� �ΰ��ӿ��� ������ �� �ִ� Text�Դϴ�. (�ӽ��ڵ��Դϴ�. ���� ���� ����)
    public GameObject Setting;

    int maxAttackCount;         // ���ù�ư�� ���� Max ī��Ʈ �� �Դϴ�.
    int numOfCount;            // ī��Ʈ�� �Ѿ Ƚ���Դϴ�.
    
    public bool isPause = false;       // ���� �Ͻ������� üũ���ݴϴ�

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

    // ���ݹ�ư�� ���õ� �ڵ��Դϴ�.
    public void AttackButton()  // ���ݹ�ư�� ���õ� �ڵ��Դϴ�. --HYJ0712  maxAttackCount�� 1�϶� �ٷ� ������ ���ư��ԵǴ� �κм���
    {
        if (!isPause)
        {
            atkCount.text = maxAttackCount.ToString(); //UI�� ǥ��
            maxAttackCount--; // (1) 0... ��ư�� ������ Ƚ����ŭ ����

            if (maxAttackCount == 0) //���� ī��Ʈ�� ( 1 -> 0 ) �� �ٴٸ���
            {
                numOfCount++; // (1) 2 3 4.. ������ ���� ��ư�� ������ �ϴ� Ƚ�� ����
                maxAttackCount += numOfCount; // ���� �Ѱ��� Ƚ���� ����
                playerInfo.Attack(); // bullet�߻�      
            }
        }
    }

    // ����Ƚ���� 1�� �ʱ�ȭ ��Ű�� ��ư�� ���õ� �ڵ��Դϴ�.
    public void ResetButton()
    {
        if (MoneyManager.starCoin >= 500)
        {
            if (!isPause)
            {
                // ��� ��ġ �ʱ�ȭ
                maxAttackCount = 1;
                numOfCount = 1;
                atkCount.text = maxAttackCount.ToString();

                MoneyManager.starCoin -= 500;
            }
        }
    }





    // ����Ƚ���� 1�� �ʱ�ȭ ��Ű�� ��ư�� ���õ� �ڵ��Դϴ�.
    public void BMButton()
    {
        if (MoneyManager.starCoin > 500)
        {
            if (!isPause)
            {
                // ��� ��ġ �ʱ�ȭ
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

    public void TestStarCoinPlus()  // �׽�Ʈ�� StarCoin(���ݸӴ�) �����Դϴ�.
    {
        MoneyManager.starCoin += 100000;
    }
}
