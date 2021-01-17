using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    public static Game Instance = null;

    public int KiwaiiHealAmount = 7;
    public int KowaiiBreakAmount = 7;

    public float KiwaiiHitRubbleScore = -5;
    public float KiwaiiCatchCatScore = 10;
    public float KiwaiiRepairHouseScore = 5;
    public float KowaiiBreakHouseScore = -10;
    public float KowaiiHitHeartScore = 5;

    public UnityEvent OnGameOver;

    public float _score = 0;
    public bool gameover = false;

    public List<FixableDestructable> Destructables = new List<FixableDestructable>();

    /// <summary>
    /// -100 for happy and +100 for angry population
    /// </summary>
    public float score
    {
        get => _score;
        set
        {
            _score = Mathf.Clamp(value, -100, 100);
            if (value != 0) Events.Instance.InvokeEv(Events.eScoreChange, _score);
        }
    }

    public float time = 100;


    public void Awake()
    {
        Instance = this;
        Events.Instance.Subscribe(HandleEvents);
    }

    public void Start()
    {
        //AkSoundEngine.PostEvent("MainMusic", gameObject);
    }


    public void Update()
    {
        //AkSoundEngine.SetRTPCValue("Score", _score);
        if (gameover) return;

        time -= Time.deltaTime;
        Events.Instance.InvokeEv(Events.eTimer, time);

        if(time <= 0)
        {
            Events.Instance.InvokeEv(Events.eGameOver, null);
            OnGameOver.Invoke();
        }

    }

    public void HandleEvents(string name, object arg)
    {
        if(name == Events.eDestructableFixed)
        {
            score = score + KiwaiiRepairHouseScore;
        }

        if(name == Events.eDestructableBroken)
        {
            score = score + KowaiiBreakHouseScore;
        }
    }


}
