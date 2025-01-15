using UnityEngine;
using EzySlice;

public class StoneDoDamage : MonoBehaviour
{
    [SerializeField]float cutforce;
    [SerializeField] Material sliceMaterial;
    VelocityEstimator velocityEstimator;
    Transform startSlicePos;
    Transform endSlicePos;
    AudioSource audioSource;
    ParticleSystem _particleSystem;
    int damage;

    /// <summary>
    /// This function gets the slice positions of the blade and the velocityEstimator component
    /// </summary>
    void Start()
    {
        _particleSystem = transform.GetChild(2).GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        startSlicePos = transform.GetChild(0).transform;
        endSlicePos = transform.GetChild(1).transform;
        velocityEstimator = endSlicePos.GetComponent<VelocityEstimator>();
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Destructible"))
        {
            audioSource.Play();
            _particleSystem.Play();
            
            DestructibleStats destructibleStats = collision.gameObject.GetComponent<DestructibleStats>();
 
            destructibleStats.DoDamage(damage);

            if(destructibleStats.canDestroy)
            {
                Slice(collision.gameObject);
            }
        }
        float radius = 1;
        float power = 200;
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.tag != "Player") // heel mooi geschreven door mij, Tamara. Dit kan zeker niet mooier of beter.
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                }
            }
        }
        Destroy(gameObject,2);
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
}
