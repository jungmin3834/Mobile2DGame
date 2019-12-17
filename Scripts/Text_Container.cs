using System.Collections;
using System.Collections.Generic;

public class TextItem
{
    string title ="";
    string context = "";
    string playercontext = "";

    public TextItem()
    {

    }

    public TextItem(string str)
    {
        string[] temp = str.Split('@');
        title = temp[0];
        context = temp[1];
        playercontext = temp[2];
    }

    public string getTitle()
    {
        return title;
    }

    public string getContext()
    {
        return context;
    }

    public string getPlayerContext()
    {
        return playercontext;
    }
}


public class Text_Container
{
    List<TextItem> main = new List<TextItem>();
    List<TextItem> scout = new List<TextItem>();
    List<TextItem> character = new List<TextItem>();
    List<TextItem> main_attack = new List<TextItem>();
    List<TextItem> attack = new List<TextItem>();
    List<TextItem> choice = new List<TextItem>();
    List<TextItem> character_choice = new List<TextItem>();

    //List<TextItem> scout = new List<TextItem>();
    //높은 등급의 에스퍼네요!\n그럼 에스퍼를 확인해보러 가보죠.
    public Text_Container()
    {
        initMainText();
        initScoutText();
        initCharacterText();
        initMainAttackText();
        initAttackRobyText();
        initChoiceCharacter();

        character_choice.Add(new TextItem("연구원 유라@에스퍼의 스킬과 특성, 장비를 확인할 수 있고,\n" +
       "레벨업과 강화를 시킬 수 있답니다.@ "));
    }

    public void initMainText()
    {
        main.Add(new TextItem("연구원 유라@아, 오셨나요?@ "));

        main.Add(new TextItem("@@이곳은 이테르...\n에스퍼를 소집해 이인종과 싸우는 곳이다.\n그리고 ... 내가 여기 있는 이유는..."));

        main.Add(new TextItem("연구원 유라@그렇게 멍하니 있을 시간이 없어요!\n" +
            "자, 어서 중요한 것들을 설명할테니 잘 익혀두세요.@"));

        main.Add(new TextItem("연구원 유라@우선 메인 화면에 대해 설명할게요.\n" +
                        "상단에서 행동력과 달러, 유료재화인 젬스톤의\n확인과 충전이 가능합니다.@"));

        main.Add(new TextItem("연구원 유라@중앙에는 대표 에스퍼가 보여지게 돼요.\n" +
                        "지금은 설정된 에스퍼가 없네요.\n" +
                        "자, 그럼 우선 에스퍼를 스카웃해볼까요?@"));
    }

    public void initScoutText()
    {
        scout.Add(new TextItem("연구원 유라@이곳에서 에스퍼를 스카웃할 수 있어요.\n" +
            "젬스톤 270개로 스카웃을 해볼까요?@ "));
        scout.Add(new TextItem("@" +
            "@"));
        scout.Add(new TextItem("연구원 유라@높은 등급의 에스퍼네요!\n" +
            "그럼 에스퍼를 확인해보러 가보죠.@ "));

   
    }

    public void initCharacterText()
    {
        // == 케릭터 선택창
        character.Add(new TextItem("연구원 유라@이곳에서 보유 에스퍼 확인과 관리가 가능해요.\n" +
        "방금 스카웃한 에스퍼를 터치해보세요.@ "));
    }

    public void initMainAttackText()
    {
        main_attack.Add(new TextItem("연구원 유라@이제 본격적으로 에스퍼와 함께 싸워볼까요?@"));
        main_attack.Add(new TextItem("@@@"));
        main_attack.Add(new TextItem("연구원 유라@이런, 이인종이에요!\n바로 전투를 준비해야겠어요.@"));
        main_attack.Add(new TextItem("연구원 유라@월드맵을 눌러 전투를 준비해요!@"));
 
    }

    public void initAttackRobyText()
    {
        attack.Add(new TextItem("연구원 유라@연신내역 1번 출구에 이인종이 나타났어요.\n어서 가볼까요?@"));
    }

    public void initChoiceCharacter()
    {
        choice.Add(new TextItem("연구원 유라@방금 스카웃한 에스퍼를 팀에 편성해봅시다.\n" +
         "첫 전투는 저와 다른 에스퍼님이 동행할거예요.@"));
        choice.Add(new TextItem("칼카스@......\n영 못 미더운데.@"));
    }
    
    public List<TextItem> getCharacter_ChoiceText()
    {
    
        return character_choice;
    }

    public List<TextItem> getChoiceCharacterText()
    {
        return choice;
    }

    public List<TextItem> getAttackPageText()
    {
        return attack;
    }

    public List<TextItem> getAttackMainText()
    {
        return main_attack;
    }

    public List<TextItem> getCharacterText()
    {
        return character;
    }

    public List<TextItem> getScoutText()
    {
        return scout;
    }

    public List<TextItem> getMainText()
    {
        return main;
    }

}
