using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerscript : MonoBehaviour
{
    public quizlevelmanager manager;
    public level1manager level1;
    public bool iscorrect = false;



    public void answers()
    {
        if (iscorrect == true)
        {
            level1.correct();
            scoremanager.instance.addpoints();
            manager.level1panel.Play("Level1panel");
            manager.coin1.gameObject.SetActive(true);
            manager.coin1.Play("coin1");
            manager.coin2.gameObject.SetActive(true);
            manager.coin2.Play("coin2");
        }
        else
        {
            manager.gameoverpanel();

            //manager.gameoverpanel();


            Debug.Log("Answer not correct");
        }
    }

}
