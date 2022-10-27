using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoremanager : MonoBehaviour
{
    public static scoremanager instance;
    public float score;
    public float highscore;
    public float totalscore;

    public Text scoretext;
    public Text highscoretext;


    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore");
        totalscore = PlayerPrefs.GetFloat("totalscore");
    }


    public void addpoints()
    {
        score += 10f;
        totalscore += 10f;
    }

    void Update()
    {
        scoretext.text = score.ToString();
        highscoretext.text = highscore.ToString();
        PlayerPrefs.SetFloat("totalscore", totalscore);

        if (score >= highscore)
        {
            highscoretext.text = scoretext.text;
            PlayerPrefs.SetFloat("highscore", score);
        }
    }
}
