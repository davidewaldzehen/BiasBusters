using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenuHandler : MonoBehaviour {

    public GameObject mainMenuCanvas;
    public GameObject playCanvas;
    public GameObject categoriesCanvas;
    //public Canvas tutorialCanvas;
    //public GameObject optionsCanvas;
    //public GameObject profileCanvas;
    public GameObject quizUI;
    public UIScript quizScript;
	public GameObject tutorialCanvas;



    // Use this for initialization
    void Start () {
        quizScript = quizUI.GetComponent<UIScript>();
	}

    public void tutorial()
    {
        playCanvas.gameObject.SetActive(false);
        quizScript.playMode = 2;
        quizScript.category = -2;
		//quizScript.setQuestionPool();
		quizUI.gameObject.SetActive(true);
        tutorialCanvas.gameObject.SetActive(true);
    }

    public void deathmatch()
    {
        playCanvas.gameObject.SetActive(false);
        quizScript.playMode = 1;
        quizScript.category = -1;
		quizScript.setQuestionPool();
        quizUI.gameObject.SetActive(true);
		//quizScript.displayNextQuestion();
    }

    public void categories()
    {
        playCanvas.gameObject.SetActive(false);
        quizScript.playMode = 0;
        categoriesCanvas.gameObject.SetActive(true);
    }

    public void back()
    {
        playCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    }
}
