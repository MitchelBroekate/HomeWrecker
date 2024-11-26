using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoDamage : MonoBehaviour
{
    [SerializeField] int weaponRange;

    [SerializeField] LayerMask destructibleLayer;

    RaycastHit _hit;

    void Start()
    {
        weaponRange = 1000;
    }

    void Update()
    {
        ItemDetection();
    }

    void ItemDetection()
    {
        if(!Physics.Raycast(transform.position, transform.forward, out _hit, weaponRange, destructibleLayer)) return;
    }
}
