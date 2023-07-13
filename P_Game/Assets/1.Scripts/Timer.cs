using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float LimitTime;
    public bool IsGameRun = true;
 
    public Text timeText;
    public GameObject gameOverPop;

    void Start()
    {
        LimitTime = 60f;
        StartCoroutine(TimeOverCheck());
    }


    IEnumerator TimeOverCheck() 
    {
        while (IsGameRun)
        {
            LimitTime -= Time.deltaTime;
            timeText.text = LimitTime.ToString("#");
            yield return null;

            if (LimitTime <0.5f)
            {
                gameOverPop.SetActive(true); //½ÇÆÐ½Ã overPop
                IsGameRun = false;
                
            }
        }
    }
}
