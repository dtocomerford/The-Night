using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverAnimation : MonoBehaviour
{
    public Image fillImage;
    public float increaseFillSpeed = 2.0f;
    public float decreaseFillSpeed = 2.0f;

    public bool cursorOn = false;


    private void Update()
    {
        if (cursorOn)
        {
            fillImage.fillAmount += increaseFillSpeed * Time.deltaTime;
        }
        else
        {
            if (fillImage.fillAmount > 0)
            {
                fillImage.fillAmount -= decreaseFillSpeed * Time.deltaTime;
            }
        }
    }

    public void OnCursorEnter()
    {
        ToggleCursorOn();
    }

    public void OnCursorExit()
    {
        ToggleCursorOn();
    }

    public void ToggleCursorOn() => cursorOn = !cursorOn;
}
