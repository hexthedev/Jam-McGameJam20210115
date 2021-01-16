using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public GameObject projectilePrefab;
    public abstract void DoAbility();

    protected virtual void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            DoAbility();
        }
#endif
    }
}
