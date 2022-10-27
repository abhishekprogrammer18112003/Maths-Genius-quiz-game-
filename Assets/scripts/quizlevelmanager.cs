using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quizlevelmanager : MonoBehaviour
{
    public leaderboard LeaderBoard;
    public int highscore;
    public GameObject[] levels;
    public float index;
    public float timerwatchad = 5f;

    public float initialtimer = 3;
    public Text initialcountdowntext;
    public Text watchadtimertext;






    public GameObject Gameoverpanel, panel, scorepanel, mainmenubtn, restartbtn, watchadpanel;
    public Text highscoretext, scoretext;
    public GameObject mainmenupanel, restartpanel;

    public Animator level1panel, level2panel, level3panel, level4panel, level5panel, level6panel;
    public Animator coin1, coin2, gameoverpanelanimation, mainmenuanim, restartanim;

    public AudioSource timer, btnclick, gameoveraudio;
    public Button watchadbtn;

    public GameObject leaderboardpanel ;
    








    void Start()
    {
        highscore = (int)PlayerPrefs.GetFloat("highscore");
        bgaudiomanager.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
        index = PlayerPrefs.GetFloat("whichlevelclicked");
        Time.timeScale = 1f;
        Invoke("gamestart", 3.5f);
        StartCoroutine(initialcountdown());
        unityads.instance.InitializeAds();
    }

    

    void gamestart()
    {

        levels[((int)index)].gameObject.SetActive(true);
    }
    IEnumerator initialcountdown()
    {
        while (initialtimer > 0)
        {
            initialcountdowntext.text = initialtimer.ToString();
            yield return new WaitForSeconds(1f);
           
            initialtimer--;
        }

    }




    public void gameoverpanel()
    {




        timer.mute = true;

        Time.timeScale = 0f;
        panel.SetActive(false);
        scorepanel.SetActive(false);
        mainmenubtn.SetActive(false);
        restartbtn.SetActive(false);
        Gameoverpanel.SetActive(true);
        levels[((int)index)].gameObject.SetActive(false);
        highscoretext.text = PlayerPrefs.GetFloat("highscore").ToString();
        scoretext.text = scoremanager.instance.score.ToString();
        gameoverpanelanimation.Play("gameoveranimation");
        gameoveraudio.Play();
        //leaderboard.SubmitScoreRoutine((int)PlayerPrefs.GetFloat("highscore"));
        //leaderboard.StartCoroutine(SubmitScoreRoutine(highscore));


    }



    public void gameovermainmenubtnclicked()
    {
        bgaudiomanager.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = false;
        btnclick.Play();
        SceneManager.LoadScene("level scene");
        StartCoroutine(LeaderBoard.SubmitScoreRoutine((int)PlayerPrefs.GetFloat("highscore")));
    }
    public void gameoverrestartbtnclicked()
    {
        btnclick.Play();
        SceneManager.LoadScene("level1");
    }


    public void mainmenubtnclicked()
    {
        timer.mute = true;
        btnclick.Play();
        mainmenuanim.Play("mainmenuanim");
        mainmenubtn.SetActive(false);
        mainmenupanel.SetActive(true);
        //levels[((int)index)].gameObject.SetActive(false);

        Time.timeScale = 0f;
        mainmenuanim.Play("mainmenuanim");
    }
    public void mainmenuyesbtnclicked()
    {
        bgaudiomanager.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = false;
        btnclick.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("level scene");
    }
    public void nobtnclicked()
    {
        timer.mute = false;
        btnclick.Play();
        Time.timeScale = 1f;
        mainmenubtn.SetActive(true);
        mainmenupanel.SetActive(false);
        restartbtn.SetActive(true);
        restartpanel.SetActive(false);
        //levels[((int)index)].gameObject.SetActive(true);

    }

    public void restartbtnclicked()
    {
        timer.mute = true;
        btnclick.Play();

        restartbtn.SetActive(false);
        restartpanel.SetActive(true);
        // levels[((int)index)].gameObject.SetActive(false);

        Time.timeScale = 0f;
        restartanim.Play("restartanim");
    }
    public void restartyesbtnclicked()
    {
        btnclick.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("level1");
    }



    public void homebtnclicked()
    {
        bgaudiomanager.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = false;
        btnclick.Play();
        SceneManager.LoadScene("mainmenu");
    }

    public void cancelbtnclick()
    {
        watchadpanel.SetActive(false);
        gameoverpanel();
    }

    public void watchadpanelfunt()
    {

        watchadpanel.SetActive(true);
        panel.SetActive(false);
        scorepanel.SetActive(false);
        mainmenubtn.SetActive(false);
        restartbtn.SetActive(false);
        Gameoverpanel.SetActive(true);
        levels[((int)index)].gameObject.SetActive(false);

        gameoverpanel();


    }


    // public void watchadbtnclicked()
    // {
    //     Time.timeScale = 0f;

    // }

    public void wronganswer()
    {
        Time.timeScale = 1f;
        watchadpanelfunt();
        Gameoverpanel.SetActive(false);

        StartCoroutine(countdownwatchad());
    }






    public IEnumerator countdownwatchad()
    {
        while (timerwatchad >= 0)
        {
            watchadtimertext.text = timerwatchad.ToString();
            yield return new WaitForSeconds(1f);
            //yield return Leaderboard.SubmitScoreRoutine(highscore);
            timerwatchad--;
            if (timerwatchad == 0)
            {
                watchadpanel.SetActive(false);
                gameoverpanel();
            }
        }

    }


    public void leaderboardbtnclicked(){
        leaderboardpanel.SetActive(true);
    }

    // IEnumerator mainmenubtnclickedforscoreupload(){
    //     Time.timeScale = 0f;
    //     yield return new WaitForSeconds(0.2f);
    //     //yield return leaderboard.SubmitScoreRoutine(highscore);
    //     Time.timeScale = 1f;
    //     SceneManager.LoadScene("level scene");
        

    






}
