using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{   
    [SerializeField] private TextMeshProUGUI timer;

    //start is called before the first frame update
    void start()
    {
        StartCoroutine(DoTimer());
    }


    private void ondisable()
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
}
