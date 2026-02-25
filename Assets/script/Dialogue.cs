using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events ;


public enum EffectType
{
    typewritter = 0
}

public class Dialogue : MonoBehaviour
{
    [SerializeField] GameObject btnobj;
    public TMP_Text m_text;

    [Range(0,1)]public float speed = 1;
    
    private void Awake()
    {
        gameObject.TryGetComponent<TMP_Text>(out m_text);
    }

    // Start is called before the first frame update
    void Start()
    {
        // btnobj.SetActive(false);
        StartCoroutine(TypeWritter());
    }

    private IEnumerator TypeWritter()
    {
        m_text.ForceMeshUpdate();
        TMP_TextInfo textInfo = m_text.textInfo;
        int total = textInfo.characterCount;
        bool complete = false;
        int current = 0;
        while (!complete)
        {
            if (current > total)
            {
                current = total;
                yield return new WaitForSecondsRealtime(0.5f);
                complete = true;
                btnobj.SetActive(true);
            }

            m_text.maxVisibleCharacters = current;
            current += 1;
            yield return new WaitForSecondsRealtime(speed);
            
        }

        yield return null;
    }
    
    // void Update()
    // {
    //     StartCoroutine(TypeWritter());
    // }

}

