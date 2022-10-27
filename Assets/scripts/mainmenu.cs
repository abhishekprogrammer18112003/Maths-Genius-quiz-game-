using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public AudioSource bgmusic;
    public GameObject panel, loadingpanel;
    public Animator loadinganim;
    void Start()
    {
        Time.timeScale = 1f;
        bgmusic.Play();
        unityads.instance.InitializeAds();

    }
    public void playbtnclicked()
    {
        panel.SetActive(false);
        loadingpanel.SetActive(true);
        loadinganim.Play("loadinganim");
        Invoke("changescene", 2f);
    }

    void changescene()
    {
        SceneManager.LoadScene("level scene");
    }


    public void rate(){
        Application.OpenURL("market://details?id=com.LNStudio.MathGenius");
    }
}
