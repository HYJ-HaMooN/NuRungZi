using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyManager : MonoBehaviour
{
    public Text Money;
    public Text StarCoin;       // ���ݸӴ�(starCoin) ǥ�ÿ� Text�Դϴ�.

    public static Func<int> action;

    public static int money;
    public static int starCoin; // ���ݸӴ�(starCoin) ������Դϴ�.

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Money.text = $"{string.Format("{0:n0}",money)}";
        StarCoin.text = $"{string.Format("{0:n0}", starCoin)}";
    }
}
