using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushPullBar : MonoBehaviour
{  
    public Image foreGroundBarImage;

    private float maxScore = 1f;
    private float currentScore;
    private float barScoreValue;


    public void Awake()
    {
        Events.Instance.Subscribe(HandleEvent);
    }

    public void Start()
    {        
        Events.Instance.InvokeEv("ScoreChange", 0.5f);
        currentScore = maxScore;
        barScoreValue = maxScore;
    }
    

    public void SetScore(float score)
    {
        foreGroundBarImage.transform.localScale = new Vector3(score / 10, foreGroundBarImage.transform.localScale.y, foreGroundBarImage.transform.localScale.z);

        Debug.Log(currentScore);
        currentScore = score;
    }

    float t = 0;
    private void Update()
    {
        if (barScoreValue != currentScore)
        {
            barScoreValue = Mathf.Lerp(barScoreValue, currentScore, t);
            t += 1f * Time.deltaTime;
        }

        foreGroundBarImage.fillAmount = barScoreValue;
    }

    public void HandleEvent(string name, object args)
    {
        if (name == Events.eScoreChange)
        {
            SetScore((float)args);
        }
    }
}
