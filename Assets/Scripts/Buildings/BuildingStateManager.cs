using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStateManager : MonoBehaviour
{
    public BuildingState State;    

    public GameObject FixedObj;
    public GameObject BreakingObj;
    public GameObject DestroyedObj;

    public Collider2D col;

    public void Start()
    {
        ChangeState(State);
    }

    public void StateFromHealth(float health)
    {
        if (health == 0) ChangeState(BuildingState.DESTROYED);
        else if (health == 100) ChangeState(BuildingState.FIXED);
        else ChangeState(BuildingState.BREAKING);
    }

    public void ChangeState(BuildingState state)
    {
        switch (state) 
        {
            case BuildingState.FIXED:
                SetEnabled(FixedObj, true, BreakingObj, DestroyedObj);
                break;
            case BuildingState.BREAKING:
                SetEnabled(BreakingObj, true, FixedObj, DestroyedObj);
                break;
            case BuildingState.DESTROYED:
                SetEnabled(DestroyedObj, false, BreakingObj, FixedObj);
                break;
        }
    }

    private void SetEnabled(GameObject en, bool canLandOnPlatform, params GameObject[] dis)
    {
        en.SetActive(true);
        col.enabled = canLandOnPlatform;

        foreach(GameObject ob in dis)
        {
            ob.SetActive(false);
        }
    }

    public enum BuildingState
    {
        FIXED, 
        BREAKING, 
        DESTROYED
    }
}
