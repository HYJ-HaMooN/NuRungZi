using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maxHp = 20;
    public float curHp = 0;
    public Slider hpSlider;
    
    int killCount;

    private void Start()
    {
        curHp = maxHp;
    }

    public void OnEnable() { curHp = maxHp; } //���� ü�� �ʱ�ȭ
    private void Update()
    {
        gameObject.transform.position =
            Vector2.MoveTowards(gameObject.transform.position, new Vector2(5.15f, -1), 15f * Time.deltaTime);

        hpSlider.value = curHp / maxHp;

        if (curHp <= 0)
        {
            //FindObjectOfType<EnemySpawner>().killCount++;   // ����
            //gameObject.SetActive(false);
            MoneyManager.money += 100;
            gameObject.SetActive(false);
        }
    }
}