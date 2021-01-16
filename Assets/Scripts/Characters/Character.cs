using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public FixDestructProximator proximator;

    public abstract void BasicAction();

    public void StunAction()
    {

    }

    public abstract void ProjectileCollision(AbilityProjectile proj);
}
