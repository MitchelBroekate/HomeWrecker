using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaraTestRotateScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool inAnim = false;
    private float swingSpeed = 500; // Krijg de tering Unity - Tamara.
    void Start()
    {
        
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
}
