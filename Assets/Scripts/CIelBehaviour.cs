using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIelBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource lvlEnd;
    // Start is called before the first frame update
    void Start()
    {
        GameController.instance.triggerCielEntered.AddListener(levelCompleted);
    }

    void levelCompleted()
    {
        lvlEnd.Play();
        Debug.Log("Vyhral si");
    }
}
