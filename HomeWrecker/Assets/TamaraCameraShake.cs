using System.Collections;
using UnityEngine;

public class TamaraCameraShake : MonoBehaviour
{
    private Vector3 originalPosition;
    public Transform cam;
    bool isShaking = false;
    float smerigeTamaraFix = 1;

    void Start()
    {
        // Save the original position of the camera
        originalPosition = cam.localPosition;
    }

    private void Update()
    {
        if(smerigeTamaraFix > 0.10f)
        {
            smerigeTamaraFix -= Time.deltaTime;
        }
        else
        {
            isShaking = false;
        }
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        if(!isShaking)
        {
            smerigeTamaraFix = 1;
            isShaking = true;
            float elapsed = 0.0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                cam.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

                elapsed += Time.deltaTime;

                yield return null;
            }
            cam.localPosition = originalPosition;
            isShaking = false;
        }
    }
}