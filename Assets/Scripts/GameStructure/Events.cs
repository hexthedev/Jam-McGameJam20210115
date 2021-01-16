using System;
using System.Collections.Generic;

using UnityEngine;


public class Events : MonoBehaviour
{
    public const string eTimer = "Timer";
    public const string eScoreChange = "ScoreChange";
    public const string eGameOver = "GameOver";
    public const string eDestructableFixed = "DestructableFixed";
    public const string eDestructableBroken = "DestructableBroken";


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

    public void Unsubscribe(Action<string, object> callback)
    {
        Subs.Remove(callback);
    }

    public void InvokeEv(string name, object arg)
    {
        foreach(Action<string, object> call in Subs)
        {
            if(call != null) call(name, arg);
        }
    }

}
