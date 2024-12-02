using UnityEngine;
using EzySlice;
using System.Collections;

public class WeaponDoDamage : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float weaponCooldown;

    Transform startSlicePos;
    Transform endSlicePos;

    //bool isAttacking;
    VelocityEstimator velocityEstimator;
    LayerMask layerMaskRay;
    float cutforce = 2000;

    bool isAttacking = false;
    bool attackOnCooldown = false;
    bool doDamageOnce = true;
    
    void Start()
    {
        startSlicePos = transform.GetChild(1).transform;
        endSlicePos = transform.GetChild(2).transform;

        velocityEstimator = endSlicePos.GetComponent<VelocityEstimator>();

        layerMaskRay = LayerMask.GetMask("Destructible");
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(!isAttacking || !attackOnCooldown)
            {
                Debug.Log("Weapon Attacking");
                StartCoroutine(StartAttack());
            }
        }
    }

    void FixedUpdate()
    {
        if(isAttacking)
        {
            Vector3 direction = (endSlicePos.position - startSlicePos.position).normalized;
            if (Physics.Raycast(startSlicePos.position, direction, out RaycastHit hit, 0.7f, layerMaskRay))
            {

                GameObject target = hit.transform.gameObject;
                DestructibleStats destructibleStats = target.GetComponent<DestructibleStats>();

                if(doDamageOnce)
                {
                    destructibleStats.DoDamage(damage);

                    doDamageOnce = false;
                }

                if(destructibleStats.canDestroy)
                {
                    Slice(target);
                }
            }
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

            //Destroy(upperHull, 4);
            //Destroy(lowerHull, 4);
        }
    }

    void SetupSlicedObject(GameObject target)
    {
        Rigidbody rb = target.AddComponent<Rigidbody>();

        MeshCollider meshCollider = target.AddComponent<MeshCollider>();
        meshCollider.convex = true;

        rb.AddExplosionForce(cutforce, target.transform.position, 3);
    }

    public void SetDamage(int damageAmount)
    {
        damage = damageAmount;
    }

    public void SetCooldown(float cooldownAmount)
    {
        weaponCooldown = cooldownAmount;
    }

    IEnumerator StartAttack()
    {
        Debug.Log("Weapon Can Attack");

        isAttacking = true;
        
        yield return new WaitForSeconds(1);

        StartCoroutine(AttackCooldown());
        
        isAttacking = false;
    }

    IEnumerator AttackCooldown()
    {
        Debug.Log("Weapon Cooldown");

        attackOnCooldown = true;

        yield return new WaitForSeconds(weaponCooldown);

        attackOnCooldown = false;

        doDamageOnce = true;
    }
}
