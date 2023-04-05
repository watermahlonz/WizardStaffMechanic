using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staffAbility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.abilityActivated && Grabber.selectedObject != null)
        {
            if (!Grabber.selectedObject.CompareTag("Staff"))
            {
                return;
            }
            
            Debug.Log("Work");
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 10f, LayerMask.GetMask("Enemies")))
            {

                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Zap");
                    StartCoroutine(DealDamage(hit.transform.gameObject));
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawRay(transform.position, transform.forward * 10f);
    }

    IEnumerator DealDamage(GameObject enemy)
    {
        while (enemy.GetComponent<Enemy>().Health > 0)
        {
            yield return new WaitForSeconds(1f);

            if (enemy == null)
            {
                StopCoroutine("DealDamage");
            }

            else
            {
                enemy.GetComponent<Enemy>().TakeDamage(2);
            }

        }
    }
}
