using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    public static AudioScript instance;
    public List<AudioClip> audioClip = new List<AudioClip>();
    AudioSource audio;
    public AudioSource background;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audio = GetComponent<AudioSource>();
    }

    private void Start_Sound(int idx , bool isBack = true)
    {
        if (isBack)
        {
            audio.clip = audioClip[idx];
            audio.Play();
        }
        else
        {
            background.clip = audioClip[idx];
            background.Play();
        }
    }

    public void AudioControll(bool isOn)
    {
        background.mute = isOn;
    }

    public void Click_Button()
    {
        Start_Sound(0);
    }

    public void SkipStory()
    {
        Start_Sound(7);
    }

    public void Normal_Background()
    {
        Start_Sound(2,false);
    }

    public void AlarmAttack_Background()
    {
        Start_Sound(5, false);
    }

    public void Attack_Background()
    {
        Start_Sound(6, false);
    }

    public void Stage_Background()
    {
        Start_Sound(3);
    }

}
