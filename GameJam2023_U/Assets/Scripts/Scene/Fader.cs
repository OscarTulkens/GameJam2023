using DAE.GameSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{

    // the image you want to fade, assign in inspector
    public Image img;

    public void FadeToTransparent(float Time, float waitTime)
    {
        StartCoroutine(DeactivateTransition(Time, waitTime));
    }

    public void FadeToBlack(float Time, float waitTime)
    {
        StartCoroutine(ActivateTransition(Time, waitTime)); ;
    }

    public void MakeScreenBlack()
    {
        img.color = new Color(0, 0, 0, 1);
    }


    IEnumerator ActivateTransition(float time, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        float start = 0;
        float end = 1;

        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        float alpha = 0;

        while (timer < time)
        {

            alpha = Mathf.Lerp(start, end, timer / time);

            img.color = new Color(0, 0, 0, alpha);

            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }
    }

    IEnumerator DeactivateTransition(float time, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        float start = 1;
        float end = 0;

        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        float alpha = 1;

        while (timer < time)
        {
            alpha = Mathf.Lerp(start, end, timer / time);

            img.color = new Color(0, 0, 0, alpha);

            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }
    }

}
