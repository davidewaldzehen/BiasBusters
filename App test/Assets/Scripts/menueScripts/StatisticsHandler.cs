using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsHandler : MonoBehaviour {

	public Text highscoreText;
	public Text highRankDeath;
	public Text highRankCat;

	public Text cultureText;
	public Text societyText;
	public Text environmentText;
	public Text scienceText;
	public Text economyPoliticsText;


    public GameObject profileCanvas;
	public GameObject mainMenuCanvas;
    public GameObject statisticsCanvas;
	public GameObject quizUI;
	public UIScript uiScript;

	public int highscore = 0;
	int highestDeathmatchRank = 0;
	int highestCategoryRank = 0;
	public List<List<int>> correctAnswers = new List<List<int>>();

	private int correctAnswersPoliticsEco = 0;
	private int correctAnswersCulture = 0;
	private int correctAnswersSociety = 0;
	private int correctAnswersEnvironment = 0;
	private int correctAnswersScience = 0;

	public void updateDisplay(){
		economyPoliticsText.text = "Economomy and Politics: " + correctAnswersPoliticsEco + "/35";
		cultureText.text = "Culture: " + correctAnswersCulture + "/25";
		societyText.text = "Society: " + correctAnswersSociety + "/27";
		environmentText.text = "Environment: " + correctAnswersEnvironment + "/26";
		scienceText.text = "Science: " + correctAnswersScience + "/25";

		//if(highestDeathmatchRank == 0){
		//	highRankDeath.text = "Deathmatch: Bias Believer";
		//}
		if(highestDeathmatchRank == 0){
			highRankDeath.text = "Deathmatch: Bias Baby";
		}
		if(highestDeathmatchRank == 1){
			highRankDeath.text = "Deathmatch: Bias Bachelor";
		}
		if(highestDeathmatchRank == 2){
			highRankDeath.text = "Deathmatch: Bias Boss";
		}
		if(highestDeathmatchRank == 3){
			highRankDeath.text = "Deathmatch: Bias Beast";
		}

		//if(highestCategoryRank == 0){
		//	highRankCat.text = "Category: Bias Believer";
		//}
		if(highestCategoryRank == 0){
			highRankCat.text = "Category: Bias Baby";
		}
		if(highestCategoryRank == 1){
			highRankCat.text = "Category: Bias Bachelor";
		}
		if(highestCategoryRank == 2){
			highRankCat.text = "Category: Bias Boss";
		}
		if(highestCategoryRank == 3){
			highRankCat.text = "Category: Bias Beast";
		}

		highscoreText.text = "Highscore: " + highscore;
	}

	//0 = politicsEconomics, 1 = culture, 2 = society, 3 = environment, 4 = science
	public void updateAchievements(){
		correctAnswers = uiScript.correctlyAnswered;
		correctAnswers = uiScript.getCorrectlyAnswered();

		correctAnswersPoliticsEco = correctAnswers[0].Count;
		correctAnswersCulture = correctAnswers[1].Count;
		correctAnswersSociety = correctAnswers[2].Count;
		correctAnswersEnvironment = correctAnswers[3].Count;
		correctAnswersScience = correctAnswers[4].Count;

		updateDisplay();
		SavePlayerProgress();
	}

	void OnEnable(){
		uiScript = quizUI.GetComponent<UIScript>();

	}


    // Use this for initialization
    void Start()
    {
		LoadPlayerProgress();
    }

	public int getHighestDeathmatchRank(){
		return highestDeathmatchRank;
	}

	public int getHighestCategoryRank(){
		return highestCategoryRank;
	}

	public void setHighestDeathmatchRank(int rank){
		highestDeathmatchRank = rank;
		
	}

	public void setHighestCategoryRank(int rank){
		highestCategoryRank = rank;
		
	}

	public int getHighscore(){
		return highscore;
	}

	public void setHighscore(int score){
		highscore = score;
		highscoreText.text = "Highscore: " + score;
		// kann das saven hier weg?
		SavePlayerProgress();
	}

	
    public void back()
    {
        mainMenuCanvas.gameObject.SetActive(true);
        statisticsCanvas.gameObject.SetActive(false);
    }


	private void LoadPlayerProgress(){
		if(PlayerPrefs.HasKey("highestScore")){
			highscore = PlayerPrefs.GetInt("highestScore");
			highestDeathmatchRank = PlayerPrefs.GetInt("deathmatchRank");
			highestCategoryRank = PlayerPrefs.GetInt("categoryRank");

			correctAnswersPoliticsEco = PlayerPrefs.GetInt("correctEcoAndPolitics");
			correctAnswersCulture = PlayerPrefs.GetInt("correctCulture");
			correctAnswersSociety = PlayerPrefs.GetInt("correctSociety");
			correctAnswersEnvironment = PlayerPrefs.GetInt("correctEnvironment");
			correctAnswersScience = PlayerPrefs.GetInt("correctScience");

			updateDisplay();
		}
	}

	private void SavePlayerProgress(){
		PlayerPrefs.SetInt("highestScore", highscore);

		PlayerPrefs.SetInt("correctEcoAndPolitics", correctAnswersPoliticsEco);
		PlayerPrefs.SetInt("correctCulture", correctAnswersCulture);
		PlayerPrefs.SetInt("correctSociety", correctAnswersSociety);
		PlayerPrefs.SetInt("correctEnvironment", correctAnswersEnvironment);
		PlayerPrefs.SetInt("correctScience", correctAnswersScience);

		PlayerPrefs.SetInt("deathmatchRank", highestDeathmatchRank);
		PlayerPrefs.SetInt("categoryRank", highestCategoryRank);
	}
}
