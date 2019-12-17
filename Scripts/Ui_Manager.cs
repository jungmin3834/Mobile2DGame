using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Manager : MonoBehaviour
{
    public static Ui_Manager instance;

    public bool isFirst = true;

    public string page = "";

    public GameObject BackGround;

    public List<GameObject> backGroundPage = new List<GameObject>();
    public List<GameObject> DescriptionImages = new List<GameObject>();
    public List<GameObject> Ui_HidePages = new List<GameObject>();
    public List<GameObject> hideScoutList = new List<GameObject>();

    public GameObject fightArea;


    private void Start()
    {
        instance = this;
    }


    public void Ui_PageExtraOn(string name , string remove = "")
    {
        for (int i = 9; i < backGroundPage.Count; i++)
        {
            if (name.Equals(backGroundPage[i].name))
                backGroundPage[i].SetActive(true);
            else
               backGroundPage[i].SetActive(false);
        }
        
    }

    public void BackGroundOnOff(bool isOn = true)
    {
        BackGround.SetActive(isOn); 
    }

    public void Ui_HidScoutList(string name)
    {
        for (int i = 0; i < hideScoutList.Count; i++)
        {
            if (name.Equals(hideScoutList[i].name))
                hideScoutList[i].SetActive(true);
            else
                hideScoutList[i].SetActive(false);
        }
    }

    public void Ui_Hide(bool isOn)
    {
        for (int i = 0; i < Ui_HidePages.Count - 1; i++)
            Ui_HidePages[i].SetActive(!isOn);
        Ui_HidePages[2].SetActive(isOn);
    }


    public void pageChange(string page)
    {
        for (int i = 0; i < backGroundPage.Count; i++)
        {
            if (page.Equals(backGroundPage[i].name))
                backGroundPage[i].SetActive(true);
            else
                backGroundPage[i].SetActive(false);
        }
    }

    public void OnClickChangePage(string page)
    {
        VideoControll.instance.OnClickFinish();

        BackGroundOnOff(true);
        pageChange(page);
        Ui_HidScoutList(page);


        if (isFirst == true && page == "Scout")
            InitStart_NPC.instance.startInitPage("Start_Scout", "Scout");
        else if (isFirst == true && page == "Character")
            InitStart_NPC.instance.startInitPage("Start_Main", "Character");
        else if (isFirst == true && page == "AttackMain")
            InitStart_NPC.instance.startInitPage("Start_Main", "AttackMain");
        else if (isFirst == true && page == "ChoiceArea")
            InitStart_NPC.instance.startInitPage("Start_Main", "ChoiceArea");
        else if (isFirst == true && page == "ChoiceCharacter")
        {
            AudioScript.instance.Stage_Background();
            InitStart_NPC.instance.startInitPage("Start_Main", "ChoiceCharacter");
        }
        else if (isFirst == true && page == "Fight")
        {
            AudioScript.instance.AudioControll(true);
            BackGroundOnOff(false);
            fightArea.SetActive(true);
            Invoke("FightScreenOn", 2);

        }
        else if (isFirst == true && page == "Character_Choice")
        {
            InitStart_NPC.instance.startInitPage("Start_Main", "Character_Choice");
        }
        else if (page == "Main")
        {
            AudioScript.instance.Normal_Background();
        }
    }

    void FightScreenOn()
    {
        Invoke("showSkipButton", 2.3f);
        VideoControll.instance.playVideo(2);
    }

    void showSkipButton()
    {
        Ui_HidScoutList("Fight");
    }

    public void DescriptionOnOff(string name = "")
    {
        for (int i = 0; i < DescriptionImages.Count; i++)
        {
            if (name.Equals(DescriptionImages[i].name))
                DescriptionImages[i].SetActive(true);
            else
                DescriptionImages[i].SetActive(false);
        }
    }

    public void ChangeBackGround_Dark()
    {

    }
}
