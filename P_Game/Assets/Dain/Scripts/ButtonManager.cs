using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ButtonManager : MonoBehaviour
{
    public GameObject OptionBG;
    public GameObject MenuBG;
    public GameObject EquipBG;
    public GameObject StageClear;
    public GameObject StageUnClear;
    public GameObject ShopBG;

    public GameObject[] ChestBtn;
    public GameObject[] Chest;
    public GameObject RewardBG;
    public GameObject RewardsCloseBtn;

    public ButtonManager(GameObject gameObject)
    {

    }

    private void Start()
    {
        OptionBG.SetActive(false);
        MenuBG.SetActive(false);
        EquipBG.SetActive(false);
        ShopBG.SetActive(false);
        StageClear.SetActive(false);
        StageUnClear.SetActive(false);
        Chest[0].SetActive(false);
        Chest[1].SetActive(false);
        Chest[2].SetActive(false);
    }

    public void StartBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Stage1Btn()
    {
        SceneManager.LoadScene(2);
    }
    public void Stage2Btn()
    {
        SceneManager.LoadScene(3);
    }
    public void Stage3Btn()
    {
        SceneManager.LoadScene(4);
    }
    public void ReLoadBtn()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void OptionBtn()
    {
        OptionBG.SetActive(true);
        MenuBG.SetActive(false);
    }
    public void ShopBtn()
    {
        ShopBG.SetActive(true);
        MenuBG.SetActive(false);
    }
    public void EquipBtn()
    {
        EquipBG.SetActive(true);
        MenuBG.SetActive(false);
    }
    public void MenuBtn()
    {
        Time.timeScale = 0;

        MenuBG.SetActive(true);
    }

    public void CloseBtn()
    {
        Time.timeScale = 1;    
        OptionBG.SetActive(false);
        MenuBG.SetActive(false);
        EquipBG.SetActive(false);
        ShopBG.SetActive(false);
        StageClear.SetActive(false);
        StageUnClear.SetActive(false);
    }
    public void ChestOpen()
    {
        Chest[0].SetActive(true);
        ChestBtn[0].SetActive(false);
        ChestBtn[1].SetActive(false);
        ChestBtn[2].SetActive(false);
    }
    public void ChestOpen1()
    {
        Chest[1].SetActive(true);
        ChestBtn[0].SetActive(false);
        ChestBtn[1].SetActive(false);
        ChestBtn[2].SetActive(false);
    }
    public void ChestOpen2()
    {
        Chest[2].SetActive(true);
        ChestBtn[0].SetActive(false);
        ChestBtn[1].SetActive(false);
        ChestBtn[2].SetActive(false);
    }
    public void RewardsClose()
    {
        RewardBG.SetActive(false);
    }
}
