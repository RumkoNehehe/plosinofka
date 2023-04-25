using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    void Start()
    {
        schovajSa();
        GameController.instance.triggerCielEntered.AddListener(ukazSa);
        GameController.instance.triggerNewLevel.AddListener(ResumeGame);
    }

    public void ukazSa()
    {
        gameObject.SetActive(true);
        PauseGame();
    }

    public void schovajSa()
    {
        gameObject.SetActive(false);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
#if !UNITY_WEBGL // exclude from WebGL build
        AudioListener.pause = true;
#endif
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
#if !UNITY_WEBGL // exclude from WebGL build
        AudioListener.pause = false;
#endif
    }
}

