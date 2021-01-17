using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PushPullBar : MonoBehaviour
{
    public Image foreGroundBarImage;
    private Transform sparkleTransform;
    private float maxScore = 1f;
    private float currentScore;
    private float barScoreValue;
    private float maxBarSize = 500f;


    public void Awake()
    {
        Events.Instance.Subscribe(HandleEvent);
        sparkleTransform = transform.Find("Sparkle");
    }

    public void Start()
    {
        Events.Instance.InvokeEv("ScoreChange", 0.5f);
        currentScore = maxScore / 2;
        barScoreValue = currentScore;
    }

    float t = 0;
    private void Update()
    {
        if (barScoreValue != currentScore)
        {
            barScoreValue = Mathf.Lerp(barScoreValue, currentScore, t);
            t += .05f * Time.deltaTime;
        }


        ((RectTransform)sparkleTransform).anchoredPosition = new Vector2(barScoreValue * maxBarSize, 0);
        foreGroundBarImage.fillAmount = barScoreValue;
    }

    public void SetScore(float score)
    {
        currentScore = score;
        t = 0;
    }

    public void HandleEvent(string name, object args)
    {
        if (name == Events.eScoreChange)
        {
            SetScore((float)args);
        }
    }
}
