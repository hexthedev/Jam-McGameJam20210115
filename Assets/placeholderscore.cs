using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class placeholderscore : MonoBehaviour
{
    public TMP_Text _text;

    private void Awake()
    {
        Events.Instance.Subscribe(HandleEvents);
    }

    public void HandleEvents(string name, object args)
    {
        if(name == Events.eScoreChange)
        {
            _text.text = ((float)args).ToString();
        }
    }
}
