using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
   public static SlotManager Instance;

    [Header("Scriptable�� ������ DataBase")]
    public ItemDataBase itemDataBase;

    [Header("���� �ϸ� ������� ��")]
    public Item saveItem;
    [Header("�������Ը���Ʈ")]
    public List<Slot> slots = new List<Slot>();

    private void Awake()
    {
        Instance = this;
    }

}
