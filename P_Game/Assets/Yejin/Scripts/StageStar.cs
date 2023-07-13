using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageStar : MonoBehaviour
{
    public GameObject StarZero, StarOne, StarTwo, StarThree;
    public int Stage; //�������� ����
    bool GameClear, GameOver, GameEnd; //���ӻ���
    float remainTime; //GameEnd�� ����� �ð�

    void Start()
    {
        GameEnd = false;
        GameClear = GetComponent<EnemySpawner>().isGameClear;
        GameOver = GetComponent<Timer>().IsGameRun;
    }

    void Update()
    {
        if (GameClear == true && GameEnd == false) //����Ŭ����� ��� �ð������� ������
        {
            remainTime = GetComponent<Timer>().LimitTime; //����Ŭ���� ������ �ð� ����

            // 10�� �̻� Ŭ���� �� ���� 3�� �̹��� Ȱ��ȭ
            if (remainTime >= 10) { StarThree.SetActive(true); }
            // 5�� �̻� Ŭ���� �� ���� 2��
            else if (remainTime >= 5) { StarTwo.SetActive(true); }
            // 0�� �̻� Ŭ���� �� ���� 1��
            else if (remainTime >= 0) { StarOne.SetActive(true); }
            //���� ��!
            GameEnd = true;
        }
        if (GameOver == true && GameEnd == false) //���ӿ����� ���� ������ 0��
        {
            StarZero.SetActive(true);
            GameEnd = true;
        }
    }
}