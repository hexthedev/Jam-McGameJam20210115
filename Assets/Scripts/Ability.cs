using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
#if UNITY_EDITOR
    public bool testOnClick = false;
#endif

    public GameObject projectilePrefab;
    public abstract void DoAbility();

    protected virtual void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            if(testOnClick) DoAbility();
        }
#endif
    }
}
