using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Kowaii : Character
{
    public override void BasicAction()
    {
        FixableDestructable fd = proximator.Prox;

        if (fd != null) fd.Break(Game.Instance.KowaiiBreakAmount);
    }

    public override void ProjectileCollision(AbilityProjectile proj)
    {
        switch (proj.Type)
        {
            case AbilityProjectile.ProjecileType.CAT:
                // CANT BE HIT BY
                break;
            case AbilityProjectile.ProjecileType.DEBRIS:
                // CANT BE HIT BY
                break;
            case AbilityProjectile.ProjecileType.HEART:
                Game.Instance.score += Game.Instance.KowaiiHitHeartScore;
                break;
            case AbilityProjectile.ProjecileType.STUN:
                //stun
                break;
        }


        Destroy(proj.gameObject);
    }
}
