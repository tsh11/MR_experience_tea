using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorObject : MonoBehaviour
{
    public GameObject objectToActivate;
    public float waitime;

    private void Start()
    {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {
        objectToActivate.SetActive(false);

        //Wait for 14 secs.
        yield return new WaitForSeconds(waitime);

        //Turn My game object that is set to false(off) to True(on).
        objectToActivate.SetActive(true);

        //Turn the Game Oject back off after 1 sec.
        // yield return new WaitForSeconds(1);



    }
}
