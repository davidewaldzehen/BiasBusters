using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoriesMenuHandler : MonoBehaviour {

    public GameObject playCanvas;
    public GameObject categoriesCanvas;
    public GameObject quizUI;
    public UIScript quizScript;
    // Use this for initialization
    void Start () {
        quizScript = quizUI.GetComponent<UIScript>();

    }

	// 0 = politicsEconomics, 1 = culture, 2 = society, 3 = environment, 4 = science

    public void politicsEconomics()
    {
        categoriesCanvas.gameObject.SetActive(false);
        quizScript.category = 0;
		quizScript.setQuestionPool();
        quizUI.gameObject.SetActive(true);
		//quizScript.displayNextQuestion();
    }

    public void culture()
    {
        categoriesCanvas.gameObject.SetActive(false);
        quizScript.category = 1;
		quizScript.setQuestionPool();
        quizUI.gameObject.SetActive(true);
		//quizScript.displayNextQuestion();
    }

    public void society()
    {
        categoriesCanvas.gameObject.SetActive(false);
        quizScript.category = 2;
		quizScript.setQuestionPool();
        quizUI.gameObject.SetActive(true);
		//quizScript.displayNextQuestion();
    }

    public void environment()
    {
        categoriesCanvas.gameObject.SetActive(false);
        quizScript.category = 3;
		quizScript.setQuestionPool();
        quizUI.gameObject.SetActive(true);
		//quizScript.displayNextQuestion();
    }

    public void science()
    {
        categoriesCanvas.gameObject.SetActive(false);
        quizScript.category = 4;
		quizScript.setQuestionPool();
        quizUI.gameObject.SetActive(true);
		//quizScript.displayNextQuestion();
    }

    public void back()
    {
        categoriesCanvas.gameObject.SetActive(false);
        playCanvas.gameObject.SetActive(true);
    }
}
