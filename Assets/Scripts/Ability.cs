using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public GameObject projectilePrefab;
    public abstract void DoAbility();
}
