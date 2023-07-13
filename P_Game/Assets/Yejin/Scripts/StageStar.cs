using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageStar : MonoBehaviour
{
    public GameObject StarZero, StarOne, StarTwo, StarThree;
    public int Stage; //스테이지 구분
    bool GameClear, GameOver, GameEnd; //게임상태
    float remainTime; //GameEnd시 저장될 시간

    void Start()
    {
        GameEnd = false;
        GameClear = GetComponent<EnemySpawner>().isGameClear;
        GameOver = GetComponent<Timer>().IsGameRun;
    }

    void Update()
    {
        if (GameClear == true && GameEnd == false) //게임클리어시 즉시 시간정보를 가져옴
        {
            remainTime = GetComponent<Timer>().LimitTime; //게임클리어 순간의 시간 저장

            // 10초 이상 클리어 시 별이 3개 이미지 활성화
            if (remainTime >= 10) { StarThree.SetActive(true); }
            // 5초 이상 클리어 시 별이 2개
            else if (remainTime >= 5) { StarTwo.SetActive(true); }
            // 0초 이상 클리어 시 별이 1개
            else if (remainTime >= 0) { StarOne.SetActive(true); }
            //게임 끝!
            GameEnd = true;
        }
        if (GameOver == true && GameEnd == false) //게임오버시 별의 개수는 0개
        {
            StarZero.SetActive(true);
            GameEnd = true;
        }
    }
}