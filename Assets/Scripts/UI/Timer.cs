using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text text;

    public void Awake()
    {
        Events.Instance.Subscribe(HandleOnEvent);
    }

    public void SetTime(float time)
    {
        text.text = time.ToString("0.00");
    }

    public void HandleOnEvent(string evtName, object args)
    {
        if (evtName == Events.eTimer)
        {
            float time = (float)args;
            SetTime(time);
        }
    }
}
