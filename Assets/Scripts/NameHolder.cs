using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameHolder : MonoBehaviour
{
    public static NameHolder instance;

    public string playerName;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
