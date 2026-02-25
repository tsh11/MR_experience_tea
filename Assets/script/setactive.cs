using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setactive : MonoBehaviour
{
    [SerializeField] GameObject prevobj;
    // Start is called before the first frame update
    void Start()
    {
        prevobj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
