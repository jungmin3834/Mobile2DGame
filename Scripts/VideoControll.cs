using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControll : MonoBehaviour
{
    public List<VideoClip> vpclip = new List<VideoClip>();
    VideoPlayer vp;
    public static VideoControll instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        vp = GetComponent<VideoPlayer>();
        vp.clip = vpclip[0];
    }

    public void setLoop(bool isOn)
    {
        vp.isLooping = isOn;
    }

    public bool isVideo()
    {
        return vp.isPlaying;
    }

    public void playVideo(int idx = 0)
    {
        vp.clip = vpclip[idx];
        vp.Play();
    }

    public void OnClickFinish(int idx = 0)
    {
        vp.Stop();
    }

}
