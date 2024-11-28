using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using Unity.VisualScripting;
using UnityEngine.UI;

public class WeaponDoDamage : MonoBehaviour
{
    Transform startSlicePos;
    Transform endSlicePos;
    bool isAttacking;
    VelocityEstimator velocityEstimator;
    public LayerMask layerMask;
    float cutforce = 2000;

    void Start()
    {
        startSlicePos = transform.GetChild(1).transform;
        endSlicePos = transform.GetChild(2).transform;

        velocityEstimator = endSlicePos.GetComponent<VelocityEstimator>();

        layerMask = LayerMask.GetMask("Destructible");
    }

    void FixedUpdate()
    {
        bool hitObject = Physics.Raycast(startSlicePos.position, endSlicePos.position, out RaycastHit hit, ~layerMask);
        if (hitObject)
        {
            Debug.Log("Object hit");

            GameObject target = hit.transform.gameObject;

            Slice(target);
        }
    }

    void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePos.position - startSlicePos.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePos.position, planeNormal);

        if(hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target);
            SetupSlicedObject(upperHull);

            GameObject lowerHull = hull.CreateLowerHull(target);
            SetupSlicedObject(lowerHull);

            Destroy(target);
        }
    }

    void SetupSlicedObject(GameObject target)
    {
        Rigidbody rb = target.AddComponent<Rigidbody>();

        MeshCollider meshCollider = target.AddComponent<MeshCollider>();
        meshCollider.convex = true;

        rb.AddExplosionForce(cutforce, target.transform.position, 3);
    }
}
