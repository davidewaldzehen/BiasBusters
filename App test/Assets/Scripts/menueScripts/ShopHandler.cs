using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : MonoBehaviour {

    public GameObject profileCanvas;
    public GameObject shopCanvas;

    // Use this for initialization
    void Start()
    {

    }

    public void back()
    {
        profileCanvas.gameObject.SetActive(true);
        shopCanvas.gameObject.SetActive(false);
    }
}
