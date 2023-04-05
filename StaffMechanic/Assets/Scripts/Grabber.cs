using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Any object that has the pickup tag can be picked up and moved around. Example is the Soul object which is spawned when an enemy is killed. Players pick it up and drop it onto 
    the statue
*/

public class Grabber : MonoBehaviour
{
    //Object that has been selected and will be set null when not picked up
    public GameObject selectedObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject == null)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    if (hit.transform.CompareTag("Pickup"))
                    {
                        selectedObject = hit.transform.gameObject;
                    }
                } 
            }

            else
            {
                selectedObject = null;
            }
        }

        if (selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);
        }
    }
}
