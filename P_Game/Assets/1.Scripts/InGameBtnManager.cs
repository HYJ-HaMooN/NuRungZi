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
    public void AttackButton()
    {
        if (!isPause)
        {
            if (maxAttackCount == 1)
            {
                numOfCount++;

                maxAttackCount += numOfCount;

                // �÷��̾ ������ �� Bullet �������� �����մϴ�.
                playerInfo.Attack();
            }

            maxAttackCount--;

            atkCount.text = maxAttackCount.ToString();
        }
    }

    // ����Ƚ���� 1�� �ʱ�ȭ ��Ű�� ��ư�� ���õ� �ڵ��Դϴ�.
    public void BMButton()
    {
        if (!isPause)
        {
            // ��� ��ġ �ʱ�ȭ
            maxAttackCount = 1;
            numOfCount = 1;
            atkCount.text = maxAttackCount.ToString();
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
}
