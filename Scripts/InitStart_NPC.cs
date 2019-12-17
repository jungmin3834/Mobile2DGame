using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InitStart_NPC : MonoBehaviour
{
    public static InitStart_NPC instance;

    public GameObject NPC;

    private bool isNext = false;
    private bool doNext = false;
    public bool isText = false;

    public Animator anim;


    private void Start()
    {
        instance = this;
        anim = NPC.GetComponent<Animator>();
        startInitPage("Start_Main", "Main");
        isNext = true;
    }

    void NPC_Active(bool isOn = true)
    {
        NPC.SetActive(isOn);
    }

    public void startInitPage(string animtype, string type, int idx = 0)
    { 
        NPC_Active();
        anim.SetTrigger(animtype);
        StartCoroutine(setTextMainPageInit(type,idx));
    }

    
    public void isNextChange(bool isOn)
    {
        isNext = isOn;
    }

    public void IsNextText()
    {
        if (isNext == true)
            doNext = true;
    }

 
    
    bool setPageinit(string page ,int idx)
    {
        switch (page)
        {
            case "Main": return Page_Controll.instance.mainPage(idx);
            case "Scout":  return Page_Controll.instance.scoutPage(idx);
            case "Character": return Page_Controll.instance.CharacterPage(idx);
            case "AttackMain": return Page_Controll.instance.AttackPage(idx);           
            case "ChoiceArea": return Page_Controll.instance.ChoiceArea(idx);
            case "ChoiceCharacter": return Page_Controll.instance.ChoiceCharacter(idx);
            case "Character_Choice": return Page_Controll.instance.Character_Choice(idx);
          //  case "Fight": return Page_Controll.instance.ChoiceCharacter(idx);
            default: return Page_Controll.instance.CleanText();
        }
    }

    IEnumerator setTextMainPageInit(string page , int idx = 0)
    {
        isText = true;
        yield return new WaitForSeconds(0.4f);
        setPageinit(page, idx++);
        yield return new WaitForSeconds(1f);
        while (true)
        {
            yield return null;
            if (doNext == true)
                break;
        }

        while (true)
        {
            yield return null;

            if (doNext == false || VideoControll.instance.isVideo() == true)
                continue;
           
            doNext = false;
            isNext = false;

            if (setPageinit(page, idx++) == false)
                break;

        }
        setPageinit("", 0);
        anim.SetTrigger("Nothing");

        NPC.SetActive(false);
        isText = false;

        Ui_Manager.instance.Ui_HidScoutList(page.Equals("AttackMain") ? "Main" : page);
        if (page.Equals("AttackMain") && idx == 2)
            Invoke("AttackTimer", 1);
    }

    void AttackTimer()
    {
        Debug.Log("작동!");
        startInitPage("Start_Main", "AttackMain", 2);
    }
}
