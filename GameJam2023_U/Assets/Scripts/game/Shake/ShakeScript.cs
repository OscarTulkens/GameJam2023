using UnityEngine;
using System.Collections;

public class ShakeScript : MonoBehaviour
{
    public float shakeStrength = .1f;
    public float ShakeIncrease = 0.005f;

    public float ShakeSpeed = 0.05f;

    float shake_intensity;

    Vector3 originPosition;
    Quaternion originRotation;
    Transform _transform;

    Coroutine ShakingCR;

    //Temporary button for testing
    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 40, 80, 20), "Shake"))
        {
            Shake(10);
        }

        if (GUI.Button(new Rect(20, 60, 80, 20), "Stop"))
        {
            StopShaking();
        }
    }

    void OnEnable()
    {
        _transform = transform;
    }

    IEnumerator ShakeIt(float maxShakeTime)
    {
        float shaketime = 0;

        while (shaketime < maxShakeTime)
        {
            _transform.localPosition = new Vector3(originPosition.x + Random.Range(-shake_intensity, shake_intensity) * .2f,
                originPosition.y + Random.Range(-shake_intensity, shake_intensity) * .2f, originPosition.z);

            //originPosition + Random.insideUnitSphere * shake_intensity;

            _transform.localEulerAngles = new Vector3(0,
                0, _transform.localEulerAngles.z + Random.Range(-shake_intensity, shake_intensity) * 2f);

            //_transform.localRotation = new Quaternion(
            //    originRotation.x + Random.Range(-shake_intensity, shake_intensity) * .2f,
            //    originRotation.y + Random.Range(-shake_intensity, shake_intensity) * .2f,
            //    originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2f,
            //    originRotation.w + Random.Range(-shake_intensity, shake_intensity) * .2f);
            shake_intensity += ShakeIncrease;
            shaketime += ShakeSpeed;
            yield return new WaitForSeconds(ShakeSpeed);
        }

        ShakingStopped();

        yield return null;
    }

    void ShakingStopped()
    {
        
        _transform.localPosition = originPosition;
        _transform.localRotation = originRotation;
    }

    public void StopShaking()
    {
        StopCoroutine(ShakingCR);
        _transform.localPosition = originPosition;
        _transform.localRotation = originRotation;
    }

    public void Shake(float maxShakeTime)
    {
        originPosition = _transform.localPosition;
        originRotation = _transform.localRotation;

        shake_intensity = shakeStrength;
        ShakingCR = StartCoroutine(ShakeIt(maxShakeTime));
    }
}
