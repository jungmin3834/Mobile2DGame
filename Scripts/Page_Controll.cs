using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_Controll : MonoBehaviour
{
    NPC_TextControll textControll;

    public static Page_Controll instance;
    public GameObject NPC;
    public GameObject NPCbackground;

    private void Start()
    {
        textControll = GameObject.Find("NPC_Manager").GetComponent<NPC_TextControll>();
        instance = this;
    }



    void DescriptionOnOff(string name)
    {
        Ui_Manager.instance.DescriptionOnOff(name);
    }

    public bool mainPage(int idx)
    {
       // return false;
        DescriptionOnOff("");
        if (textControll.textChange("Main", idx) == false)
        {
            Ui_Manager.instance.Ui_PageExtraOn("Main_MainScout_Touch");
            return false;
        }

        if (idx == 3)
            DescriptionOnOff("Dark_Top");
        else if (idx == 4)
            DescriptionOnOff("Dark_Bottom");
        else
            DescriptionOnOff("Dark_BackGround");
        return true;
    }

    public bool scoutgetCharacterPage(int idx)
    {
        return false;
    }

    public bool scoutPage(int idx)
    {

        if (idx == 0)
        {
            textControll.textChange("Scout", idx);
            Ui_Manager.instance.Ui_PageExtraOn("Main_ScoutGet_Touch");
            return false;
        }
        else if (idx == 1)
        {
            textControll.textChange("Scout", idx);
        }
        else if (idx == 2)
        {
            if (textControll.textChange("Scout", idx) == true)
                return true;
        }
        else
        {
            if (textControll.textChange("Scout", idx) == false)
            {
                Ui_Manager.instance.Ui_PageExtraOn("Main_GoCharacter_Touch", "Main_ScoutYes_Touch");
                return false;
            }
        }

 
        DescriptionOnOff("");
        return false;
      
    }

    public bool CharacterPage(int idx)
    {
       
        DescriptionOnOff("Dark_BackGround");

        if (textControll.textChange("Character", idx) == false)
        {
            Ui_Manager.instance.Ui_PageExtraOn("Main_clickCharacter_Touch");
            return false;
        }
        return true;
    }

    IEnumerator delayText(string commend = "" ,float time = 0,int idx = 0)
    {
        yield return new WaitForSeconds(time);
        textControll.textChange("ChoiceCharacter", idx);
    }

    public bool Character_Choice(int idx)
    {
        if (textControll.textChange("Character_Choice", idx) == false)
        {
           
            return false;
        }
        return true;
    }

    public bool ChoiceCharacter(int idx)
    { 
        DescriptionOnOff("Dark_BackGround");
        if (idx == 0)
        {
            if (textControll.textChange("ChoiceCharacter", idx) == false)
                return false;
        }
        else if (idx == 1)
        {
            StartCoroutine(delayText("ChoiceCharacter", 0.3f, idx));
            InitStart_NPC.instance.anim.SetTrigger("Start_Choice");
        }
        else
        { 
            return false;
        }
        return true;
    }

    public bool ChoiceArea(int idx)
    {
        
        DescriptionOnOff("Dark_Tutorial");

        if (textControll.textChange("ChoiceArea", idx) == false)
        {
            Ui_Manager.instance.Ui_PageExtraOn("Main_FightChoice_Touch");
            return false;
        }
        return true;
    }
   

    public bool AttackPage(int idx)
    {
        NPC.SetActive(true);
        NPCbackground.SetActive(true);

        if (idx == 1)
        {
            return false;
        }
        if (idx == 2)
        {
            AudioScript.instance.AlarmAttack_Background();
            DescriptionOnOff("Dark_Attack");
        }
        else if (idx == 3)
        {
            AudioScript.instance.Attack_Background();
            NPC.SetActive(false);
            NPCbackground.SetActive(false);
            DescriptionOnOff("Dark_WorldMap");
        }
        else
        {
            NPC.SetActive(true);
            NPCbackground.SetActive(true);
            DescriptionOnOff("Dark_WorldMap");
        }

        if (textControll.textChange("AttackMain", idx) == false)
        {
            Ui_Manager.instance.Ui_PageExtraOn("Main_TouchWorldMap_Touch" ,"");
            return false;
        }
        return true;
    }

    public bool CleanText()
    {
        textControll.textChange("");
        return false;
    }

}
