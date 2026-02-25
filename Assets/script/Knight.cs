
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    [SerializeField] public Button button_1;    // First button
    [SerializeField] private Vector3 fixedPosition = new Vector3(0, 1, 1);

    private int currentObjectIndex = 0;
    private bool isInitialized = false;

    //void Start()
    //{
    //    if (button_1!= null)
    //    {
    //        button_1.onClick.AddListener(SpawnNextObject);
    //        button_1.gameObject.SetActive(false);

    //    }

    //}
    public void SpawnNextObject()
    {
        currentObjectIndex++;

        // If we exceed the number of objects, hide button_2
        if (currentObjectIndex >= objects.Count)
        {
            button_1.gameObject.SetActive(false);
            return;
        }

        // Deactivate the current object and activate the next one in the list
        if (currentObjectIndex > 0 && currentObjectIndex < objects.Count)
        {
            objects[currentObjectIndex - 1].SetActive(false);
            Debug.Log(currentObjectIndex);
            objects[currentObjectIndex].SetActive(true);
        }

        // Set the position of the next object
        objects[currentObjectIndex].transform.position = new Vector3(0, 1, 1);
    }
}
