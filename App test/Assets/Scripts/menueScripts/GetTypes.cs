using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetTypes : MonoBehaviour {

    public Text[] texts;
    public Button[] buttons;

    void Start()
    {
        texts = transform.GetComponentsInChildren<Text>(true); // returns array of all children that have the component (inactive included).
        buttons = transform.GetComponentsInChildren<Button>(true);
    }
}
