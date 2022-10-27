using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundaudiomanager : MonoBehaviour
{
    [SerializeField] Image soundonicon, soundofficon;
    private bool muted = false;
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            load();
        }
        else
        {
            load();
        }
        updatebtnicon();
        AudioListener.pause = muted;
    }
    void load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    void updatebtnicon()
    {
        if (muted == false)
        {
            soundonicon.enabled = true;
            soundofficon.enabled = false;
        }
        else
        {
            soundonicon.enabled = false;
            soundofficon.enabled = true;
        }
    }
    public void onbtnpressed()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        save();
        updatebtnicon();
    }

    void save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
