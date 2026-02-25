using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.Events ;


public class countdownwthobj : MonoBehaviour
{
    [SerializeField] GameObject result;
    [SerializeField] GameObject timerobj;
    [SerializeField] GameObject randomobj;
    //[SerializeField] GameObject nextbtn;
    
    [SerializeField] Image imageTime;
    [SerializeField] Text timeText;
    [SerializeField] float duration, currentTime;
    // Start is called before the first frame update
    void Start()
    {
        randomobj.SetActive(false);
        //nextbtn.SetActive(false);
        result.SetActive(false);
        
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
        
    }

    IEnumerator TimeIEn()
    {
        while(currentTime >= 0)
        {
            imageTime.fillAmount = Mathf.InverseLerp(0,duration,currentTime);
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        OpenObj();
    }

    // Update is called once per frame
    void OpenObj()
    {
        timeText.text = "";
        timerobj.SetActive(false);
        randomobj.SetActive(true);
        //nextbtn.SetActive(true);
        result.SetActive(true);
    }
}
