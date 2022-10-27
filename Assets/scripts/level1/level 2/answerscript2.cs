using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerscript2 : MonoBehaviour
{
    public quizlevelmanager manager;
    public level2manager level2;
    public bool iscorrect = false;


    public void answers()
    {
        if (iscorrect == true)
        {
            level2.correct();
            scoremanager.instance.addpoints();
            manager.level2panel.Play("Level1panel");
            manager.coin1.gameObject.SetActive(true);
            manager.coin1.Play("coin1");
            manager.coin2.gameObject.SetActive(true);
            manager.coin2.Play("coin2");
        }
        else
        {
            manager.gameoverpanel();
            Debug.Log("Answer not correct");
        }
    }
}
