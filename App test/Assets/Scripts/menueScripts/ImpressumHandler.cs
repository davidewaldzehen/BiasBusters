using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpressumHandler : MonoBehaviour {

    public GameObject mainMenuCanvas;
    public GameObject impressumCanvas;


    public void back()
    {
        impressumCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    }
}
