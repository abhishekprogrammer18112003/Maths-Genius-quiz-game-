using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level5manager : MonoBehaviour
{
    public quizlevelmanager manager;
    public List<questionsandanswers> qna;
    public GameObject[] options;
    public int currentquestions;
    public Text questiontext;
    public Text timetext;
    public GameObject intialcountdowntext;
    // float initialcountdown = 3;
    public GameObject level5panel;


    void Start()
    {
        manager.timer.Play();
        gamestart();
        // level2panel.SetActive(false);
        // Time.timeScale = 1f;
        // Invoke("gamestart", 3.5f);

    }
    void gamestart()
    {
        intialcountdowntext.SetActive(false);
        level5panel.SetActive(true);
        generaterandomquestions();
        StartCoroutine(countdown());
    }


    void generaterandomquestions()
    {
        manager.timer.Play();
        if (qna.Count > 0)
        {
            currentquestions = Random.Range(0, qna.Count);
            questiontext.text = qna[currentquestions].questions;
            setanswers();
        }
        else
        {
            Debug.Log("Out of questions");
        }
    }
    void setanswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<answerscript5>().iscorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = qna[currentquestions].answers[i];
            if (qna[currentquestions].correctanswer == i + 1)
            {
                options[i].GetComponent<answerscript5>().iscorrect = true;
            }
        }
    }

    public void correct()
    {
        qna.RemoveAt(currentquestions);
        generaterandomquestions();

    }


    IEnumerator countdown()
    {
        while (qna[currentquestions].timer >= 0)
        {
            timetext.text = qna[currentquestions].timer.ToString();
            yield return new WaitForSeconds(1f);
            qna[currentquestions].timer--;
            if (qna[currentquestions].timer == 0)
            {
                manager.gameoverpanel();
            }
        }

    }
}
