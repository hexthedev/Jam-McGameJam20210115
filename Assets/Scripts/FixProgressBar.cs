using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixProgressBar : MonoBehaviour
{
    private Image progressBarImage;
    public float hideTime;
    public float hideDelay;
    private bool isHiding;

    // Start is called before the first frame update
    void Start()
    {
        progressBarImage = GetComponent<Image>();
        progressBarImage.color = new Color(1, 1, 1, 0); ;
        isHiding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHiding)
        {
            Color color = progressBarImage.color;
            progressBarImage.color = new Color(color.r, color.b, color.g, color.a - Time.deltaTime / hideTime);

            if(progressBarImage.color.a <= 0)
            {
                isHiding = false;
                enabled = false;
            }
        }
    }

    public void UpdateProgressBar(int health, int maxhealth)
    {
        CancelInvoke();
        progressBarImage.fillAmount = (float)health / maxhealth;
        progressBarImage.color = Color.white;
        Invoke(nameof(HideProgressBar), hideDelay);
    }

    public void HideProgressBar()
    {
        isHiding = true;
    }
}
