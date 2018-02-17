using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpHandler : MonoBehaviour {

    public GameObject mainMenuCanvas;
    public GameObject helpCanvas;


    public void back()
    {
        helpCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    }
}
