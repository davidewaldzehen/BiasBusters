using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTexts : MonoBehaviour {

    public Text[] texts;

    void Start () {
        texts = transform.GetComponentsInChildren<Text>(true); // returns array of all children that have the component (inactive included).
    }
}
