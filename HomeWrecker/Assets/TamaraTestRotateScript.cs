using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaraTestRotateScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool inAnim = false;
    private float swingSpeed = 500; // Krijg de tering Unity - Tamara.
    public bool dikkeKlap;
    public TamaraCameraShake camShake;
    void Start()
    {
        camShake = Camera.main.GetComponent<TamaraCameraShake>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(DoSwing());
        }
    }

    public IEnumerator DoSwing() {
        if (!inAnim)
        {
            transform.localEulerAngles = new Vector3(0, -90, 0); // Dit is smerig, maar nodig. - Tamara.
            float rotated = 0; 
            inAnim = true;
            while(rotated < 90)
            {
                float toAdd = Time.deltaTime * swingSpeed;
                transform.Rotate(new Vector3(0, 0, -toAdd));
                rotated += toAdd;
                yield return null;
            }
            if (dikkeKlap)
            {
                DoExplosion();
            }
            while(rotated > 0)
            {
                float toAdd = Time.deltaTime * swingSpeed;
                transform.Rotate(new Vector3(0, 0, toAdd));
                rotated -= toAdd;
                yield return null;
            }
            inAnim = false;
            transform.localEulerAngles = new Vector3(0, -90, 0);
        }
    }

    public void DoExplosion()
    {
        float radius = 1;
        float power = 200;
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if(hit.gameObject.tag != "Player") // heel mooi geschreven door mij, Tamara. Dit kan zeker niet mooier of beter.
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                }
            }
        }
    }
}
