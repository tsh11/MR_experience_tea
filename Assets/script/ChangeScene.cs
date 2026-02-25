using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasgroup;

    private bool _fadein = false;
    private bool _fadeout = false;

    public float TimetoFade;
    public float timetochangescene;

    void Update()
    {
        if (_fadein)
        {
            if (canvasgroup.alpha < 1)
            {
                canvasgroup.alpha += TimetoFade * Time.deltaTime;
                if (canvasgroup.alpha >= 1)
                {
                    _fadein = false;
                }
            }
        }
        if (_fadeout)
        {
            if (canvasgroup.alpha >= 0)
            {
                canvasgroup.alpha -= TimetoFade * Time.deltaTime;
                if(canvasgroup.alpha == 0)
                {
                    _fadeout = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        _fadein=true;
    }

    public void FadeOut()
    {
        _fadeout=true;
    }

    public void changescene()
    {
        StartCoroutine(Fadeonscenechange());
    }

    IEnumerator Fadeonscenechange()
    {
        FadeOut();
        yield return new WaitForSeconds(timetochangescene);
        SceneManager.LoadScene("part3");
    }
    

}
