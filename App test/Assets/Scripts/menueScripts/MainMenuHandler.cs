using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour {

    public GameObject mainMenuCanvas;
    public GameObject playCanvas;
    public GameObject lexiconCanvas;
    public GameObject optionsCanvas;
    public GameObject statisticsCanvas;
    public GameObject impressumCanvas;
    public GameObject helpCanvas;
	public GameObject quizUI;
	public UIScript quizScript;


    // Use this for initialization
    void Start () {
		// activate and deactivate quizCanvas shortly so the start-method will run
		quizScript = quizUI.GetComponent<UIScript>();
		quizScript.initQuestionPools();

		statisticsCanvas.gameObject.SetActive(true);
		statisticsCanvas.gameObject.SetActive(false);

		optionsCanvas.gameObject.SetActive(true);
		optionsCanvas.gameObject.SetActive(false);
	}

    // main menu
    public void play()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        playCanvas.gameObject.SetActive(true);
    }

    public void lexicon()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        lexiconCanvas.gameObject.SetActive(true);
    }

    public void options()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        optionsCanvas.gameObject.SetActive(true);
    }

    public void statistics()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        statisticsCanvas.gameObject.SetActive(true);
    }

    public void impressum()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        impressumCanvas.gameObject.SetActive(true);
    }

    public void help()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        helpCanvas.gameObject.SetActive(true);
    }

    public void quit()
    {
		//PlayerPrefs.DeleteAll();
        print("should quit");
        Application.Quit();
		
    }
}
