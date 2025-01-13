using UnityEngine;
using EzySlice;
using System.Collections;

public class WeaponDoDamage : MonoBehaviour
{
    //THIS SCRIPT MAKES USE OF 2 EXTERNAL ASSETS (I COULDN'T FIND ENOUGH INFORMATION WITHIN 50 HOURS ABOUT PROCEDURAL DESTRUCTION)//

    #region Variables
    [Header("Config Variables")]
    [SerializeField]float cutforce;

    [Header("Linked Variables")]
    PlayerController playerController;
    [SerializeField] int damage;
    [SerializeField] Material sliceMaterial;
    VelocityEstimator velocityEstimator;
    LayerMask layerMaskRay;
    Transform startSlicePos;
    Transform endSlicePos;
    bool isAttacking = false;
    bool doDamageOnce = true;
    Animator weaponAnimator;
    #endregion
    
    /// <summary>
    /// This function gets the slice positions of the blade, the velocityEstimator component, and sets the layermask for the damage detection
    /// </summary>
    void Start()
    {
        startSlicePos = transform.GetChild(0).transform.GetChild(0).transform;
        endSlicePos = transform.GetChild(0).transform.GetChild(1).transform;

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        velocityEstimator = endSlicePos.GetComponent<VelocityEstimator>();

        layerMaskRay = LayerMask.GetMask("Destructible");

        weaponAnimator = GetComponent<Animator>();
    }

    /// <summary>
    /// This function checks if the a mousebutton is pressed and enables the attack state. Checks for a destructible object and does damage to that object or slices it if the object is out of health
    /// </summary>
    void Update()
    {
        if(!playerController.PlayerLock)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                if(!isAttacking)
                {
                    Debug.Log("Weapon Attacking");

                    StartCoroutine(StartAttack());
                    
                    weaponAnimator.SetBool("IsAttacking", true);

                    doDamageOnce = true;
                }
            }

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

    }

    /// <summary>
    /// This function allows an object to be sliced by splitting the UV and calculating which direction the weapon is going
    /// </summary>
    /// <param name="target"></param>
    void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePos.position - startSlicePos.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePos.position, planeNormal);

        if(hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, sliceMaterial);
            SetupSlicedObject(upperHull);

            GameObject lowerHull = hull.CreateLowerHull(target, sliceMaterial);
            SetupSlicedObject(lowerHull);

            Destroy(target);

            //If we want the objects to disappear after a few seconds
            //Destroy(upperHull, 4);
            //Destroy(lowerHull, 4);
        }
    }

    /// <summary>
    /// Gives the Sliced object(Upper- and Lowerhull) Components and adds some force to the splitting
    /// </summary>
    /// <param name="target"></param>
    void SetupSlicedObject(GameObject target)
    {
        Rigidbody rb = target.AddComponent<Rigidbody>();

        MeshCollider meshCollider = target.AddComponent<MeshCollider>();
        meshCollider.convex = true;

        DestructibleStats destructibleStats = target.AddComponent<DestructibleStats>();
        destructibleStats.SetHealth(0);
        destructibleStats.SetScore(0);
        destructibleStats.SetDestroyable();
        target.layer = LayerMask.NameToLayer("Destructible");

        rb.AddExplosionForce(cutforce, target.transform.position, 3);
    }

    /// <summary>
    /// This function sets the damage of the weapon
    /// </summary>
    /// <param name="damageAmount"></param>
    public void SetDamage(int damageAmount)
    {
        damage = damageAmount;
    }

    /// <summary>
    /// This function gives a time periode where the player does damage(for the animation)
    /// </summary>
    /// <returns></returns>
    IEnumerator StartAttack()
    {
        Debug.Log("Weapon Can Attack");

        isAttacking = true;
        
        yield return new WaitForSeconds(0.8f);

        weaponAnimator.SetBool("IsAttacking", false);
        
        isAttacking = false;
    }
}
