using UnityEngine;

using AK;

public class DOSOund : MonoBehaviour
{
    public void soundPLease()
    {
        AkSoundEngine.PostEvent("Test", gameObject);
    }
}
