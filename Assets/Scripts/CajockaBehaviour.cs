using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajockaBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDestroy()
    {
        GameController.instance.triggerCajockaDestroyed.Invoke();
    }
}
