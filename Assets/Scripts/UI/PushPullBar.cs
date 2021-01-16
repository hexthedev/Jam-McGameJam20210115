using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushPullBar : MonoBehaviour
{
    public Image image;

    public void SetScore(float score)
    {
        image.transform.localScale = new Vector3(score / 10, image.transform.localScale.y, image.transform.localScale.z);
    }
}
