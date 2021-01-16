using System;
using System.Collections.Generic;

using UnityEngine;


public class Events : MonoBehaviour
{
    public const string eTimer = "Timer";

    public static Events Instance = null;

    private List<Action<string, object>> Subs = new List<Action<string, object>>();

    public void Awake()
    {
        Instance = this;
    }

    public void Subscribe(Action<string, object> callback)
    {
        Subs.Add(callback);
    }

    public void Invoke(string name, object arg)
    {
        foreach(Action<string, object> call in Subs)
        {
            call(name, arg);
        }
    }

}
