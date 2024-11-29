using UnityEngine;
using EzySlice;

public class WeaponDoDamage : MonoBehaviour
{
    Transform startSlicePos;
    Transform endSlicePos;

    //bool isAttacking;
    VelocityEstimator velocityEstimator;
    LayerMask layerMaskRay;
    float cutforce = 2000;
    
    void Start()
    {
        startSlicePos = transform.GetChild(1).transform;
        endSlicePos = transform.GetChild(2).transform;

        velocityEstimator = endSlicePos.GetComponent<VelocityEstimator>();

        layerMaskRay = LayerMask.GetMask("Destructible");
    }

    void FixedUpdate()
    {
        Vector3 direction = (endSlicePos.position - startSlicePos.position).normalized;
        if (Physics.Raycast(startSlicePos.position, direction, out RaycastHit hit, 0.7f, layerMaskRay))
        {
            Debug.Log("Raycast hit");

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

            Destroy(upperHull, 4);
            Destroy(lowerHull, 4);
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
