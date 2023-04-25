using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private int skore;
    [SerializeField]
    private TextMeshProUGUI skoreTxt;
    [SerializeField] private AudioSource points;
    void Start()
    {
        GameController.instance.triggerDoktorkoDestroyed.AddListener(resetSkore);
        GameController.instance.triggerCajockaDestroyed.AddListener(pridajSkore);
        GameController.instance.triggerCielEntered.AddListener(lvlDone);
        resetSkore();
    }

    // Update is called once per frame
    void Update()
    {
        skoreTxt.text = skoreTxt.text;
    }

    private void pridajSkore()
    {
        points.Play();
        skore = skore + 10;
        skoreTxt.text = "Points: " + skore.ToString();
    }

    private void resetSkore()
    {
        skore = 0;
        skoreTxt.text = "Points: " + skore.ToString();
    }

    private void lvlDone()
    {
        skore = 0;
    }
}
