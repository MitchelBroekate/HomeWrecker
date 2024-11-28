using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDoDamage : MonoBehaviour
{
    bool isAttacking;

    void OnTriggerEnter(Collider collision)
    {
        if (!isAttacking) return;
        
        if(collision.gameObject.layer == 7)
        {
            Debug.Log("Hit Destructible It");
        }
    }
}
