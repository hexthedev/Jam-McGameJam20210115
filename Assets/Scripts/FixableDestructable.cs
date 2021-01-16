﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixableDestructable : MonoBehaviour
{
    public int health;
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

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        isOnFixCooldown = false;
        isOnBreakCoolDown = false;
        progressBar = GetComponentInChildren<FixProgressBar>();
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
        if (!isOnBreakCoolDown)
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

        if (health == 0) Events.Instance.InvokeEv(Events.eDestructableBroken, null);
        if (health == maxHealth) Events.Instance.InvokeEv(Events.eDestructableFixed, null);
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
}
