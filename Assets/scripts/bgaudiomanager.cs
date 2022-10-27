using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgaudiomanager : MonoBehaviour
{
    private static bgaudiomanager instance = null;
    public static bgaudiomanager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
