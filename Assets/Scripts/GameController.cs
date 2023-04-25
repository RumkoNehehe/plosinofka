using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public UnityEvent triggerCielEntered = new UnityEvent();
    public UnityEvent triggerCajockaDestroyed = new UnityEvent();
    public UnityEvent triggerDoktorkoDestroyed = new UnityEvent();
    public UnityEvent triggerNewLevel = new UnityEvent();
    public UnityEvent triggerRestLvl = new UnityEvent();
    [SerializeField] private TextMeshProUGUI timer;


    private void Start()
    {
        instance.triggerRestLvl.AddListener(resetLvl);
        instance.triggerCielEntered.AddListener(koniecHry);
        StartCoroutine(DoTimer());
    }
    private void Update()
    {
        //skoreTxt.text = "Points: " + skore.ToString();
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        ResumeGame();
    }

    private void OnDisable()
    {
        StopCoroutine(DoTimer());
    }

    IEnumerator DoTimer(float countTime = 1f)
    {
        int count = 0;
        while (true)
        {
            yield return new WaitForSeconds(countTime);
            count++;
            timer.text = count.ToString();

        }
    }

    public void prepniLevel()
    {
        ResumeGame();
        SceneManager.LoadScene(2);
    }

    public void prepniTutorial()
    {
        ResumeGame();
        SceneManager.LoadScene(1);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
#if !UNITY_WEBGL // exclude from WebGL build
        AudioListener.pause = false;
#endif
    }

    public void resetLvl()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current);
    }

    public void koniecHry()
    {
        ResumeGame();
        int current = SceneManager.GetActiveScene().buildIndex;
        if(current == 2) { 
        SceneManager.LoadScene(3);
        }
    }
}
