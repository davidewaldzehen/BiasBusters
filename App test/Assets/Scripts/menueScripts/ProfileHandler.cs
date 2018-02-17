using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileHandler : MonoBehaviour {

    public GameObject mainMenuCanvas;
    public GameObject profileCanvas;
    public GameObject shopCanvas;
    public GameObject statisticsCanvas;
    public GameObject avatarCanvas;

    public void shop()
    {
        profileCanvas.gameObject.SetActive(false);
        shopCanvas.gameObject.SetActive(true);
    }

    public void statistics()
    {
        profileCanvas.gameObject.SetActive(false);
        statisticsCanvas.gameObject.SetActive(true);
    }

    public void customizeAvatar()
    {
        profileCanvas.gameObject.SetActive(false);
        avatarCanvas.gameObject.SetActive(true);
    }

    public void back()
    { 
        profileCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    }
}
