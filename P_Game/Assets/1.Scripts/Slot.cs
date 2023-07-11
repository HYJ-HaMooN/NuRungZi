using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //������ ��ư ������Ʈ�� �������ֽ�.
    private Button clickBtn;
    //�ڱ��ڽ��� ������
    public Item slotitem;
    //���° �ڽ����� 
    [SerializeField] private int slotindex;

   

    private Shop shop;
    private void Start()
    {
        //���� ������
        shop = FindObjectOfType<Shop>();
        //�ڽ��� �ڽĹ�ȣ
        slotindex = transform.GetSiblingIndex();
        //�����ͺ��̽����� ������
        slotitem =   SlotManager.Instance.itemDataBase.items[slotindex];
        //�ڽ��� ��ư ������Ʈ�� ������
        clickBtn = GetComponent<Button>();
        //�ڽ��� ��Ŭ�� �̺�Ʈ ���� - 
        clickBtn.onClick.AddListener(SetItemInfo);

        clickBtn.transform.GetChild(0).GetComponent<Image>().sprite = slotitem.animal;
    }


    private void SetItemInfo()
    { 
        //���õ� Item ���� ����
        shop.selctItem = slotitem;
        shop.selectItem_Sprite.sprite = shop.selctItem.animal;
        shop.selectItemInfo_Name.text = shop.selctItem.animalName;
        shop.selectItemInfo_Panel.gameObject.SetActive(true);

        
        shop.equipBtn.onClick.RemoveAllListeners();
        shop.exitBtn.onClick.RemoveAllListeners();

        //������ư ��Ŭ���̺�Ʈ ����
        shop.equipBtn.onClick.AddListener(EquipBtn);
        //��ҹ�ư ��Ŭ���̺�Ʈ ����
        shop.exitBtn.onClick.AddListener(ExitBtn);

    }


    public void EquipBtn()
    {
        //������ư Ŭ�� ��  - �̱������� ���� SlotManager. saveItem �� ����
        SlotManager.Instance.saveItem = shop.selctItem;
        shop.selectItemInfo_Panel.gameObject.SetActive(false);

        //����� saveItem�� �ִ� ���� �̸��� Text�� ǥ��...
        shop.equipInfo_Name.text = SlotManager.Instance.saveItem.animalName;
        shop.equipInfo_Sprite.sprite = SlotManager.Instance.saveItem.animal;

    }
    public void ExitBtn()
    {
        //��ҹ�ư Ŭ���� ���� NULL
        SlotManager.Instance.saveItem = null;
        shop.selctItem = null;
        shop.selectItemInfo_Panel.gameObject.SetActive(false);
    }


}
