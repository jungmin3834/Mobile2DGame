using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_ButtonControl : MonoBehaviour
{
    public void OnClick_None(string str = "")
    {
        AudioScript.instance.Click_Button();
        if (str == "")
        {
            
        }
        else
        {

        }
    }

    public void OnClick_getCharacter(string commnd)
    {
        AudioScript.instance.Click_Button();
        Ui_Manager.instance.Ui_PageExtraOn("Main_ScoutYes_Touch", "Main_ScoutGet_Touch");
        Ui_Manager.instance.backGroundPage[4].SetActive(true);
        Ui_Manager.instance.Ui_HidScoutList("Scout_Choice");
    }

    public void OnClick_Character(string str)
    {
        AudioScript.instance.Click_Button();
        if (str == "Okay")
        {
            AudioScript.instance.AudioControll(false);
            Ui_Manager.instance.Ui_HidScoutList("Scout");
            Ui_Manager.instance.Ui_PageExtraOn("", "");
            VideoControll.instance.OnClickFinish();
            Ui_Manager.instance.Ui_Hide(false);
            InitStart_NPC.instance.startInitPage("Start_Main", "Scout", 2);
        }
        else
        {
            VideoControll.instance.playVideo();
        }
    }

    public void OnClick_GemStoneUse(string commend)
    {
        AudioScript.instance.Click_Button();
        Ui_Manager.instance.Ui_PageExtraOn("");
        Ui_Manager.instance.backGroundPage[4].SetActive(false);
        if (commend.Equals("Okay"))
        {
            AudioScript.instance.AudioControll(true);
            VideoControll.instance.playVideo();
            Ui_Manager.instance.Ui_Hide(true);
        }
        else
        {
            Ui_Manager.instance.Ui_HidScoutList("Scout");
            Ui_Manager.instance.Ui_Hide(false);
           // Ui_Manager.instance.pageChange("Scout");
        }
           
    
    }

    public void OnClick_AreaTutorial()
    {
        //선택
    }

    public void OnClick_ChoiceCharacter(string commnd)
    {
      //  Ui_Manager.instance.OnClickChangePage(commnd);
    }




    #region 사용안하는 버튼
    #region NPC Text

    public void OnClick_IsNext()
    {
        InitStart_NPC.instance.IsNextText();
    }


    #endregion

    #region addItems
    public void OnClick_StaminaAdd()
    {
        Debug.Log("OnClick_StaminaAdd");
    }

    public void OnClick_MoneyAdd()
    {
        Debug.Log("OnClick_MoneyAdd");
    }

    public void OnClick_DiamondAdd()
    {
        Debug.Log("OnClick_DiamondAdd");
    }
    #endregion

    #region right Top
    public void OnClick_TrickAdd()
    {
        Debug.Log("OnClick_TrickAdd");
    }


    public void OnClick_SettingAdd()
    {
        Debug.Log("OnClick_SettingAdd");
    }

    public void OnClick_EmailAdd()
    {
        Debug.Log("OnClick_EmailAdd");
    }

    public void OnClick_MessageAdd()
    {
        Debug.Log("OnClick_MessageAdd");
    }
    #endregion

    #region addItems
    public void OnClick_WorldMap()
    {
     //   Ui_Manager.instance.OnClick_TestFuncion();
        Debug.Log("OnClick_WorldMap");
    }

    public void OnClick_LimitFight()
    {
        Debug.Log("OnClick_LimitFight");
    }

    
    #endregion

    #region left middle
    public void OnClick_DailyActive()
    {
        Debug.Log("OnClick_DailyActive");
    }


    public void OnClick_Event()
    {
        Debug.Log("OnClick_Event");
    }

    public void OnClick_Event2()
    {
        Debug.Log("OnClick_Event2");
    }

    #endregion
    #endregion

    #region bottom

    public void OnClick_PageChange(string page)
    {
        AudioScript.instance.AudioControll(false);
        AudioScript.instance.Click_Button();
        if (InitStart_NPC.instance.isText == true)
            return;
        Ui_Manager.instance.OnClickChangePage(page);
    }
    #endregion
}
