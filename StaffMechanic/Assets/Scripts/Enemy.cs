using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 10;
    

    public void TakeDamage(int damage)
    {
        if (Health > 0)
        {
            Health -= damage;

            if (Health <= 0)
            {
                StartCoroutine(TimeToDie());
            }  
        }
    }

    IEnumerator TimeToDie()
    { 
        yield return new WaitForSeconds(1f);
        
        Destroy(this.gameObject);
    }
}
