using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *
 * Where objects would be dragged towards to pickups for now
 * Once the statue is full then the player can pick up the staff and activate its ability
 * 
 */

public class SoulFill : MonoBehaviour
{
    public Transform staffTransform;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            GameManager.instance.currentSouls += 10;
            Destroy(collision.gameObject);

            if (GameManager.instance.currentSouls == GameManager.instance.maxSouls)
            {
                GameManager.instance.abilityActivated = true;
            }
        }
        
        else if (collision.gameObject.CompareTag("Staff") && !GameManager.instance.abilityActivated && Grabber.selectedObject != null)
        {
            Grabber.selectedObject = null;
            collision.transform.position = staffTransform.position;
        }
    }
    

}
