using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_Project : MonoBehaviour
{
    public GameObject startObject;
    public GameObject basic_BackGround;
    public GameObject canvas;
    public GameObject button1;
    public GameObject button2;

    bool skip = false;
    bool goMain = false;

    void Start()
    {
       //startObject.SetActive(true);
         VideoControll.instance.playVideo(1);
       // Destroy(basic_BackGround.gameObject , 3);
         StartCoroutine(firstVideo());
        //ShowSkipButton();
       // EnterTheGame();
    }

    public void ShowSkipButton()
    {
        AudioScript.instance.SkipStory();
        button1.SetActive(false);
        button2.SetActive(true);
         skip = true;
    }

    public void EnterTheGame()
    {
        AudioScript.instance.Normal_Background();
        button2.SetActive(false);
        goMain = true;
    }

    void startCanvas()
    {
        canvas.SetActive(true);
    }

    IEnumerator nextVideo()
    {
        VideoControll.instance.setLoop(true);
        yield return new WaitForSeconds(1);
        while (true)
        {
            yield return null;
            if (goMain == true || VideoControll.instance.isVideo() == false)
            {
                VideoControll.instance.OnClickFinish();
                VideoControll.instance.setLoop(false);
                canvas.SetActive(false);
                startObject.SetActive(true); 
                break;
            }
        }
    }

    IEnumerator firstVideo()
    {
        while (true)
        {
            yield return null;
            if (VideoControll.instance.isVideo() == true)
                break;
        }
        Invoke("startCanvas", 3);
        while (true)
        {
            yield return null;
            if(skip == true || VideoControll.instance.isVideo() == false)
            {
                VideoControll.instance.OnClickFinish(1);
                VideoControll.instance.playVideo(3);
                StartCoroutine(nextVideo());
                break;
            }

        }
    }
    
}
