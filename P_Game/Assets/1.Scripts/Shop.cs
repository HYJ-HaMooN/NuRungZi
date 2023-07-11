using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public Slot SlotPrefab;
    public GameObject parent;

    [Header("���� ������ �����")]
    public Item selctItem;

    [Header("����  ������ ���� �˾�â ������Ʈ")]
    public GameObject selectItemInfo_Panel;
    public Image selectItem_Sprite;
    public Text selectItemInfo_Name;
    public Button equipBtn;
    public Button exitBtn;


    [Header("���� UI ������Ʈ")]
    public GameObject equipInfo_Panel;
    public Image equipInfo_Sprite;
    public Text  equipInfo_Name;
    

    private void Start()
    {
        //����Ÿ���̽��� ������ִ� ��? ������? �� ����
        int index = SlotManager.Instance.itemDataBase.items.Count;
        for (int i = 0; i < index; i++)
        {
            //������ŭ ���� �� 
            Slot slot =  Instantiate(SlotPrefab, parent.transform) ;
            //List�� ������ ����
            SlotManager.Instance.slots.Add(slot);
        }

    }
}
