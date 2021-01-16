using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public TMP_Text text;

    private void OnEnable()
    {
        float score = Game.Instance.score;
        string win = score > 0 ? nameof(Kowaii) : nameof(Kiwaii);
        text.text = win;
    }
}
