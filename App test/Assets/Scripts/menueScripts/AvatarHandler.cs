using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarHandler : MonoBehaviour {

    public GameObject profileCanvas;
    public GameObject avatarCanvas;

	// Use this for initialization
	void Start () {
		
	}

    public void back()
    {
        profileCanvas.gameObject.SetActive(true);
        avatarCanvas.gameObject.SetActive(false);
    }
}
