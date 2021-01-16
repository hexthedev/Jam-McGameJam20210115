using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixDestructProximator : MonoBehaviour
{
    public float proximityThreshold = 2f;

    public FixableDestructable Prox;

    // Update is called once per frame
    void Update()
    {
        if(Prox != null)
        {
            // Will cause issue when both are in proximity and one leaves
            if( (Prox.transform.position - transform.position).magnitude > proximityThreshold)
            {
                Prox.Highlight(false);
                Prox = null;
            }
        } 
        else
        {
            float lowerstmag = float.PositiveInfinity;
            FixableDestructable obj = null;

            foreach(FixableDestructable fd in Game.Instance.Destructables)
            {
                float mag = (fd.transform.position - transform.position).magnitude;

                if(lowerstmag > mag)
                {
                    lowerstmag = mag;
                    obj = fd;
                }
            }

            if(lowerstmag < proximityThreshold)
            {
                obj.Highlight(true);
                Prox = obj;
            }
        }
    }
}
