using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStateManager : MonoBehaviour
{
    public BuildingState State;    

    public GameObject FixedObj;
    public GameObject BreakingObj;
    public GameObject DestroyedObj;

    public void Start()
    {
        ChangeState(State);
    }

    public void ChangeState(BuildingState state)
    {
        switch (state) 
        {
            case BuildingState.FIXED:
                SetEnabled(FixedObj, BreakingObj, DestroyedObj);
                break;
            case BuildingState.BREAKING:
                SetEnabled(BreakingObj, FixedObj, DestroyedObj);
                break;
            case BuildingState.DESTROYED:
                SetEnabled(DestroyedObj, BreakingObj, FixedObj);
                break;
        }
    }

    private void SetEnabled(GameObject en, params GameObject[] dis)
    {
        en.SetActive(true);

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
