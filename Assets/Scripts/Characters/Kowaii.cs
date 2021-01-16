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
}
