using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance = null;

    private float _score = 0;

    /// <summary>
    /// -100 for happy and +100 for angry population
    /// </summary>
    public float score
    {
        get => _score;
        set
        {
            _score = value;
            if (value != 0) Events.Instance.InvokeEv(Events.eScoreChange, _score);
        }
    }

    public float time = 100;


    public void Awake()
    {
        Instance = this;

    }



    public void Update()
    {
        time -= Time.deltaTime;
        Events.Instance.InvokeEv(Events.eTimer, time);

        if(time <= 0)
        {
            Events.Instance.InvokeEv(Events.eGameOver, null);
        }

    }

    public void HandleEvents(string name, object arg)
    {
        if(name == Events.eDestructableFixed)
        {
            score = score + 10;
        }

        if(name == Events.eDestructableBroken)
        {
            score = score + 10;
        }
    }


}
