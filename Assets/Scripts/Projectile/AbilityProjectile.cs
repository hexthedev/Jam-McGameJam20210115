using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityProjectile : MonoBehaviour
{
    public ProjecileType Type;

    public float lifeTime;

    void Start()
    {
        Invoke(nameof(DestroyProjectile), lifeTime);
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    public enum ProjecileType
    {
        CAT,
        DEBRIS,
        HEART,
        STUN
    }
}
