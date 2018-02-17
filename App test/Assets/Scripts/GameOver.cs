using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public GameObject progressButton;
	public Text progressText;
	public GameObject statisticsCanvas;
	public GameObject quizUI;
	public GameObject mainMenuCanvas;
	public GameObject gameOverCanvas;
	public StatisticsHandler statisticsHandler;
	public GameObject biasBelieverImg;
	public GameObject biasBabyImg;
	public GameObject biasBachelorImg;
	public GameObject biasBossImg;
	public GameObject biasBeastImg;
	UIScript script;
	int score = 0;
	int numCorrAns = 0;
	int playMode;
	string rank = "Bias Buster";
	int rankInt = 0;

	public Text scoreText;
	public Text numOfCorrAnsText;
	public Text rankText;
	public GameObject newHighscore;
	public Text newHighscoreText;
	// TODO: update questionnumber in the end
	int totalQuestionNumber = 138;


	void Awake() {
		script = quizUI.GetComponent<UIScript>();
		statisticsHandler = statisticsCanvas.GetComponent<StatisticsHandler>();
    }

	string calcRank(){
		
		if(playMode == 0){
			//if(numCorrAns < 5){
			//	rankInt = 0;
			//	return rank = "Bias Believer";
			//}
			if(numCorrAns < 9){
				rankInt = 0;
				return rank = "Bias Baby";
			}
			if(numCorrAns < 13){
				rankInt = 1;
				return rank = "Bias Bachelor";
			}
			if(numCorrAns < 17){
				rankInt = 2;
				return rank = "Bias Boss";
			}
			if(numCorrAns < 21){
				rankInt = 3;
				return rank = "Bias Beast";
			}
		}
		else if(playMode == 1){
			//if(numCorrAns < (totalQuestionNumber/5)){
			//	rankInt = 0;
			//	return rank = "Bias Believer";
			//}
			if(numCorrAns < (totalQuestionNumber/5)*1){
				rankInt = 0;
				return rank = "Bias Baby";
			}
			if(numCorrAns < (totalQuestionNumber/5)*2){
				rankInt = 1;
				return rank = "Bias Bachelor";
			}
			if(numCorrAns < (totalQuestionNumber/5)*3){
				rankInt = 2;
				return rank = "Bias Boss";
			}
			if(numCorrAns < (totalQuestionNumber/4)){
				rankInt = 3;
				return rank = "Bias Beast";
			}
		}
		else{
			print("war weder playmode 0 oder 1");
			return "this didnt work";
		}
		return "this didnt work";
	}


	public void setVariables(int lastScore, int lastNumOfCorrect, int playmode, int category){
		score = lastScore;
		numCorrAns = lastNumOfCorrect;
		playMode = playmode;
		displayStats();
	}
	

	public void displayStats(){
		scoreText.text = "" + score;
		numOfCorrAnsText.text = "You answered a total of " + numCorrAns + " questions correctly!";

		rankText.text = calcRank();
		statisticsHandler.updateAchievements();
		print(statisticsHandler.transform.gameObject.name);
		print(statisticsHandler.highscore);

		//if(rankInt == 0){
		//	biasBelieverImg.SetActive(true);
		//}
		if(rankInt == 0){
			biasBabyImg.SetActive(true);
		}
		if(rankInt == 1){
			biasBachelorImg.SetActive(true);
		}
		if(rankInt == 2){
			biasBossImg.SetActive(true);
		}
		if(rankInt == 3){
			biasBeastImg.SetActive(true);
		}

		// update statistics if new highscores or new highest rank
		if(statisticsHandler.getHighscore() <= score){
			print("yay new highscore!");
			newHighscore.SetActive(true);
			statisticsHandler.setHighscore(score);
		}

		if(playMode == 1)
			if(statisticsHandler.getHighestDeathmatchRank() <= rankInt){
				statisticsHandler.setHighestDeathmatchRank(rankInt);
			}
		if(playMode == 0){
			if(statisticsHandler.getHighestCategoryRank() <= rankInt){
				statisticsHandler.setHighestCategoryRank(rankInt);
			}
		}

		statisticsHandler.updateDisplay();
	}

	public void close(){
		mainMenuCanvas.SetActive(true);
		newHighscore.SetActive(false);
		this.gameObject.SetActive(false);

		progressButton.gameObject.SetActive(true);

		//biasBelieverImg.SetActive(false);
		biasBabyImg.SetActive(false);
		biasBachelorImg.SetActive(false);
		biasBossImg.SetActive(false);
		biasBeastImg.SetActive(false);
	}
}
