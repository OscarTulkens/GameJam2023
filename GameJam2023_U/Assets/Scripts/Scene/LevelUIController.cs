using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;

public class LevelUIController : MonoBehaviour
{
    public Fader fader;

    public float FaderSpeed;

    private void Awake()
    {
        fader.MakeScreenBlack();
        fader.FadeToTransparent(FaderSpeed, 0);

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    int currentSceneIndex;

    public void LoadNextScene()
    {
        StartCoroutine(LoadSceneRoutine(currentSceneIndex + 1, FaderSpeed));
  
    }

    public void LoadStartScene()
    {
        StartCoroutine(LoadSceneRoutine(0, FaderSpeed));

     
    }

    public void LoadGameScene()
    {
        StartCoroutine(LoadSceneRoutine(1, FaderSpeed));

       
    }

    public void LoadVictorySceneScene()
    {
        StartCoroutine(LoadSceneRoutine(2, FaderSpeed));

    }

    public void LoadLoseScene()
    {
        StartCoroutine(LoadSceneRoutine(3, FaderSpeed));

    }

    IEnumerator LoadSceneRoutine(int sceneNumber, float WaitTime)
    {
        fader.FadeToBlack(WaitTime, 0f);
        yield return new WaitForSeconds(WaitTime+ 0.2f);
        LoadScene(sceneNumber);
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }


}
