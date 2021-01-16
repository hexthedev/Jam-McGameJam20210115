using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwaii : Character
{
    public float catScore = 10;

    public Ability heartAbility;

    public override void BasicAction()
    {
        FixableDestructable fd = proximator.Prox;

        if (fd != null) fd.Fix(Game.Instance.KiwaiiHealAmount);
    }

    public override void ProjectileCollision(AbilityProjectile proj)
    {
        switch (proj.Type)
        {
            case AbilityProjectile.ProjecileType.CAT:
                Game.Instance.score += Game.Instance.KiwaiiCatchCatScore;
                heartAbility.DoAbility();
                // DO ABILITY
                break;
            case AbilityProjectile.ProjecileType.DEBRIS:
                Game.Instance.score += Game.Instance.KiwaiiHitRubbleScore;
                // STUN, Backlash?
                break;
            case AbilityProjectile.ProjecileType.HEART:
                break;
            case AbilityProjectile.ProjecileType.STUN:
                //stun
                break;
        }

        Destroy(proj.gameObject);
    }
}
