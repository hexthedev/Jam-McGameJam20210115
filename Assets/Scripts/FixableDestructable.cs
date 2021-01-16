using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixableDestructable : MonoBehaviour
{
    private int health;
    public int maxHealth;
    public float cooldownTime;
    private FixProgressBar progressBar;
    private bool isOnFixCooldown, isOnBreakCoolDown;

    public Ability OnBroken;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        isOnFixCooldown = false;
        isOnBreakCoolDown = false;
        progressBar = GetComponentInChildren<FixProgressBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fix(10);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Break(10);
        }
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
}
