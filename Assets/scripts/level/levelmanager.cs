using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class levelmanager : MonoBehaviour
{
    public int initialtimer = 1;
    public GameObject leaderBoardpanel;


    public leaderboard LeaderBoard;
    public int highscore;
    public float totalscore;
    float whichlevelclicked;
    public Text highscoretext;
    public Text totalscoretext;

    public float levelsunlocked = 0;
    public float level2price = 300;
    public float level3price = 500;
    public float level4price = 800;
    public float level5price = 1000;
    public float level6price = 1200;

    public GameObject[] level;


    public GameObject rulespanel;

    public AudioSource bgmusic, btnclick, unlocklevel;


    public Animator Rulesanim;
    public TMP_InputField playerNameInputfield;




    void Start()
    {
        StartCoroutine(Uplaodscore());
        

        //PlayerPrefs.SetString("playername",playerNameInputfield.text);
        // StartCoroutine(Uplaodscore());

        Time.timeScale = 1f;
        levelsunlocked = PlayerPrefs.GetFloat("levelsunlocked");
        for (int i = 0; i < levelsunlocked; i++)
        {
            level[i].transform.GetChild(1).gameObject.SetActive(false);
            level[i].GetComponent<Button>().interactable = true;
        }
        //bgmusic.Play();
    }


    void Update()
    {
        
        
        
        totalscore = PlayerPrefs.GetFloat("totalscore");
        totalscoretext.text = totalscore.ToString();

        highscoretext.text = PlayerPrefs.GetFloat("highscore").ToString();
        


        if (totalscore >= level2price)
        {
            level[0].transform.GetChild(1).GetComponent<Button>().interactable = true;
        }

        if (totalscore >= level3price)
        {
            level[1].transform.GetChild(1).GetComponent<Button>().interactable = true;
        }

        if (totalscore >= level4price)
        {
            level[2].transform.GetChild(1).GetComponent<Button>().interactable = true;
        }

        if (totalscore >= level5price)
        {
            level[3].transform.GetChild(1).GetComponent<Button>().interactable = true;
        }

        if (totalscore >= level6price)
        {
            level[4].transform.GetChild(1).GetComponent<Button>().interactable = true;
        }
        highscore = (int)PlayerPrefs.GetFloat("highscore");


    }
    void levelinfo()
    {
        levelsunlocked++;
        PlayerPrefs.SetFloat("levelsunlocked", levelsunlocked);
    }

    public void level2buybtnclicked()
    {

        scoremanager.instance.totalscore -= level2price;
        level[0].transform.GetChild(1).gameObject.SetActive(false);
        level[0].GetComponent<Button>().interactable = true;
        levelinfo();
        //unlocklevel.Play();

    }
    public void level3buybtnclicked()
    {

        scoremanager.instance.totalscore -= level3price;
        level[1].transform.GetChild(1).gameObject.SetActive(false);
        level[1].GetComponent<Button>().interactable = true;
        levelinfo();
        //unlocklevel.Play();

    }
    public void level4buybtnclicked()
    {

        scoremanager.instance.totalscore -= level4price;
        level[2].transform.GetChild(1).gameObject.SetActive(false);
        level[2].GetComponent<Button>().interactable = true;
        levelinfo();
        //unlocklevel.Play();

    }
    public void level5buybtnclicked()
    {

        scoremanager.instance.totalscore -= level5price;
        level[3].transform.GetChild(1).gameObject.SetActive(false);
        level[3].GetComponent<Button>().interactable = true;
        levelinfo();
        //unlocklevel.Play();

    }
    public void level6buybtnclicked()
    {

        scoremanager.instance.totalscore -= level6price;
        level[4].transform.GetChild(1).gameObject.SetActive(false);
        level[4].GetComponent<Button>().interactable = true;
        levelinfo();
        //unlocklevel.Play();

    }



    public void level1btnclicked()
    {

        whichlevelclicked = 0;
        whichlevelclickedinfo();
        SceneManager.LoadScene("level1");

    }
    public void level2btnclicked()
    {

        whichlevelclicked = 1;
        whichlevelclickedinfo();
        SceneManager.LoadScene("level1");

    }
    public void level3btnclicked()
    {

        whichlevelclicked = 2;
        whichlevelclickedinfo();
        SceneManager.LoadScene("level1");

    }
    public void level4btnclicked()
    {


        whichlevelclicked = 3;
        whichlevelclickedinfo();
        SceneManager.LoadScene("level1");

    }
    public void level5btnclicked()
    {

        whichlevelclicked = 4;
        whichlevelclickedinfo();
        SceneManager.LoadScene("level1");

    }
    public void level6btnclicked()
    {

        whichlevelclicked = 5;
        whichlevelclickedinfo();

    }


    void whichlevelclickedinfo()
    {
        PlayerPrefs.SetFloat("whichlevelclicked", whichlevelclicked);
    }




    public void exitbtnclicked()
    {

        Application.Quit();
    }

    public void rulesandregulationbtnclicked()
    {


        rulespanel.SetActive(true);
        Rulesanim.Play("rulesanim");
        btnclick.Play();

    }

    public void crossbtnclicked()
    {

        rulespanel.SetActive(false);
        btnclick.Play();
    }

     IEnumerator Uplaodscore()
    {
        while (initialtimer > 0)
        {
            
            yield return new WaitForSeconds(1f);
            yield return LeaderBoard.SubmitScoreRoutine(highscore);
            initialtimer--;
        }

    }

    public void leaderboardbtnclicked(){
        leaderBoardpanel.SetActive(true);
    }
}
