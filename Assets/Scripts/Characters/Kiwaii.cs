using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwaii : Character
{
    public override void BasicAction()
    {
        FixableDestructable fd = proximator.Prox;

        if (fd != null) fd.Fix(Game.Instance.KiwaiiHealAmount);
    }
}
