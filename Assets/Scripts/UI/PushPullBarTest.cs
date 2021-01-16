using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushPullBarTest : MonoBehaviour
{
    
    public void GoodScore()
    {
        Events.Instance.InvokeEv("ScoreChange", -.1);
    }

    public void BadScore()
    {
        Events.Instance.InvokeEv("ScoreChange", .1);
    }
}
