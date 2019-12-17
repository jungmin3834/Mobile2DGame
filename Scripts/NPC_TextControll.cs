using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_TextControll : MonoBehaviour
{
    Text_Container container;

    private void Start()
    {
        container = new Text_Container();
    }

    public TextMeshProUGUI npcTitle;
    public TextMeshProUGUI npcContext;
    public TextMeshProUGUI playerContext;

    private void setText(TextItem t)
    {
        //playerContext.text = t.getPlayerContext();
        // npcTitle.text = t.getTitle();
        //npcContext.text = t.getContext();
        StartCoroutine(setTextAnimation(t));
    }

    IEnumerator setTextAnimation(TextItem t)
    {
        npcTitle.text = t.getTitle();
        npcContext.text = "";
        playerContext.text = "";
        string context = t.getContext().Length > t.getPlayerContext().Length ? 
            t.getContext() : t.getPlayerContext();

        int size = context.Length;
        int idx = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.02f);
            InitStart_NPC.instance.isNextChange(false);
            if (idx == size)
                break;
            
            if(t.getTitle().Length==0)
                playerContext.text += context[idx++];
            else
                npcContext.text += context[idx++];
        }

        InitStart_NPC.instance.isNextChange(true);
    }

    public bool textChange(string page = "", int idx = 0)
    {
        
        TextItem t = new TextItem();
        switch (page)
        {
            case "Main":
                if (container.getMainText().Count <= idx)
                    break;
                setText(container.getMainText()[idx]);
                return true;
            case "Scout":
                if (container.getScoutText().Count <= idx)
                    break;
                setText(container.getScoutText()[idx]);
                return true;
            case "Character":
                if (container.getCharacterText().Count <= idx)
                    break;
                setText(container.getCharacterText()[idx]);
                return true;
            case "AttackMain":
                if (container.getAttackMainText().Count <= idx)
                    break;
                setText(container.getAttackMainText()[idx]);
                return true;
            case "ChoiceArea":
                if (container.getAttackPageText().Count <= idx)
                    break;
                setText(container.getAttackPageText()[idx]);
                return true;
            case "ChoiceCharacter":
                if (container.getChoiceCharacterText().Count <= idx)
                    break;
                setText(container.getChoiceCharacterText()[idx]);
                return true;
            case "Character_Choice":
                if (container.getCharacter_ChoiceText().Count <= idx)
                    break;
                setText(container.getCharacter_ChoiceText()[idx]);
                return true;

        }

        setText(t);
        return false;
    }

    
}
