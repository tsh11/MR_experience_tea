using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadein : MonoBehaviour
{

    [SerializeField] private CanvasGroup myuigroup;
    [SerializeField] private bool fadeIn = false;
    
    public void showIU()
    {
        fadeIn = true;
    }

    private void Update()
    {
        if (fadeIn)
        {
            if (myuigroup.alpha < 1)
            {
                myuigroup.alpha += Time.deltaTime;
                if (myuigroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
    }

    
}
