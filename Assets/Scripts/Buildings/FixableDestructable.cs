using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FixableDestructableHealthChangeEvent: UnityEvent<float>{ }

public class FixableDestructable : MonoBehaviour
{
    private int _health;
    public int health
    {
        get => _health;
        set
        {
            _health = value;
            _onHealthChange.Invoke(_health);
        }
    }
    public int maxHealth;
    public float cooldownTime;
    public FixProgressBar progressBar;
    public bool isOnFixCooldown, isOnBreakCoolDown;

    public int minDebris = 2;
    public int maxDebris = 7;

    public float minDebrisEmitDelay = 0.1f;
    public float maxDebrisEmitDelay = 0.4f;

    [Range(0, 1f)]
    public float DebrisProbability = 0.8f;

    public Ability DebrisAbility;

    public Renderer HighlightRenderer;
    public Material NeutralMaterial;
    public Material HighlighMaterial;

    public State state = State.FIXED;

    public FixableDestructableHealthChangeEvent _onHealthChange;

    private void Awake()
    {
        Game.Instance.Destructables.Add(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        isOnFixCooldown = false;
        isOnBreakCoolDown = false;
        progressBar = GetComponentInChildren<FixProgressBar>();
    }

    /// <summary>
    /// true is highlighted, false is not
    /// </summary>
    /// <param name="mode"></param>
    public void Highlight(bool mode)
    {
        HighlightRenderer.material = mode ? HighlighMaterial : NeutralMaterial;
    }

    public void Fix(int amount)
    {
        if (!isOnFixCooldown)
        {
            HealthChange(amount);
            isOnFixCooldown = true;
            Invoke(nameof(ResetFixCooldown), cooldownTime);
        }
    }

    public void Break(int amount)
    {
        if (!isOnBreakCoolDown && health > 0)
        {
            HealthChange(-amount);
            isOnBreakCoolDown = true;
            Invoke(nameof(ResetBreakCooldown), cooldownTime);

            if(Random.Range(0,1f) < DebrisProbability)
            {
                StartCoroutine(DoDebrisCoroutine(Random.Range(minDebris, maxDebris)));
            }
        }
    }

    private void HealthChange(int amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
        progressBar.enabled = true;
        progressBar.UpdateProgressBar(health, maxHealth);

        if (health == 0 && state != State.BROKEN)
        {
            Events.Instance.InvokeEv(Events.eDestructableBroken, null);
            state = State.BROKEN;
        } 
        else if (health == maxHealth && state != State.FIXED)
        {
            Events.Instance.InvokeEv(Events.eDestructableFixed, null);
            state = State.FIXED;
        } 
        else if(state != State.MIDDLE && health != maxHealth && health != 0)
        {
            state = State.MIDDLE;
        }
    }

    private void ResetFixCooldown()
    {
        isOnFixCooldown = false;
    }

    private void ResetBreakCooldown()
    {
        isOnBreakCoolDown = false;
    }



    public IEnumerator DoDebrisCoroutine(int number)
    {
        for(int i = 0; i<number; i++)
        {
            DebrisAbility.DoAbility();
            yield return new WaitForSeconds(Random.Range(minDebrisEmitDelay, maxDebrisEmitDelay)); 
        }
    } 

    public enum State
    {
        BROKEN, 
        MIDDLE,
        FIXED
    }
}
