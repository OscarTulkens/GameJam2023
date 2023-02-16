using UnityEngine;
using System.Collections;
using FMOD.Studio;
using FMODUnity;

public class ShakeScript : MonoBehaviour
{
    public EventReference clanknoise;

    public float StartingShakeStrenght = 0.05f;
    public float ShakeIncreaseStart = 0.05f;
    

    public float ShakeIntervall = 0.05f;

    float shake_intensity;

    Vector3 originPosition;
    Quaternion originRotation;
    Transform _transform;

    Coroutine ShakingCR;

    //Temporary button for testing
    void OnGUI()
    {
      
    }

    void OnEnable()
    {
        _transform = transform;
    }

    IEnumerator ShakeIt(float maxShakeTime)
    {
        float shaketime = 0;

        float ShakeIncrease = ShakeIncreaseStart / maxShakeTime;

        while (shaketime < maxShakeTime)
        {
            _transform.localPosition = new Vector3(originPosition.x + Random.Range(-shake_intensity, shake_intensity) * .2f,
                originPosition.y + Random.Range(-shake_intensity, shake_intensity) * .2f, originPosition.z);
                       

            _transform.localEulerAngles = new Vector3(0,
                0, _transform.localEulerAngles.z + Random.Range(-shake_intensity, shake_intensity) * 2f);

            shake_intensity += ShakeIncrease;


            shaketime += ShakeIntervall;
            yield return new WaitForSeconds(ShakeIntervall);
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
        LeanTween.scale(gameObject, transform.localScale * 1.2f, 0.4f).setEasePunch();
    }

    public void Shake(float maxShakeTime)
    {
        originPosition = _transform.localPosition;
        originRotation = _transform.localRotation;

        shake_intensity = StartingShakeStrenght;
        ShakingCR = StartCoroutine(ShakeIt(maxShakeTime));
    }
}
