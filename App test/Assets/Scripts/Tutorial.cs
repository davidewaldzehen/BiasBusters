using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public GameObject optionsCanvas;

	// Objects to be explained
	public Button Close;
	public Button LowerLeft;
	public Button LowerRight;
	public Button UpperLeft;
	public Button UpperRight;
	public GameObject Question;
	public Button questionButton;
	public GameObject Answer;
	public Button Score;
	public Button Progress;

	// Tutorial objects
	public GameObject instructionPlace1;
	public GameObject instructionPlace2;
	public GameObject instructionField;
	public Button instructionFieldButton;
	public Button next;
	public Button back;

	Color highlightColor;
	Color instructionColor;
	Color normalColor;
	List<List<string>> instructions;
	int instructionIndex = 0;


	// Use this for initialization
	void Start () {
		
		instructionColor = new Color(0.9f,0.9f,0.5f,0.9f);
		highlightColor = new Color(1f,0.5f,0.5f,1f);


		// set Colors of Tutorial in case someone changed the button colors (are always all changed)
		instructionFieldButton.image.color = instructionColor;
		next.image.color = instructionColor;
		back.image.color = instructionColor;

		// first the text to be displayed, then "0" for instructionPlace1, "1" for instructionPlace2
		instructions = new List<List<string>>{ 
			
			new List<string> { "We will now show you how to use our Quiz App. To continue with the Tutorial click 'Next'. To go back click 'Back'.", "0", "Beginn"},
			new List<string> { "The explanation always addresses the red colored part of the User Interface.", "0", "None"},
			new List<string> { "Always click the 'X' to go back to the Main Menu (in the Tutorial as well as in Game Mode).","0", "X"},
			new List<string> { "This is where the questions will be presented.","1", "Question"},
			new List<string> { "Most of the questions show you possible headlines, e.g. of newspaper articles. You have to indicate which cognitive bias can be found in it.","1", "Question"},
            new List<string> { "These are the possible answers.","0", "Answers"},
            new List<string> { "When you click on an answer you will see the correct answer (in green) or whether you selected a wrong answer (in red).","0", "AnswerColors"},
			new List<string> { "After the correct answer is shown, you can click on each answer to get more information about the respective bias/effect.","0", "AnswerColors"},
			new List<string> { "After you selected your answer, click on the question to continue.","1", "Question"},
			new List<string> { "You can either play in Deathmatch or in Category mode.","0", "nothing"},
			new List<string> { "In Category mode you get only questions with a certain topic. You get 20 questions and have to answer as many as possible correctly.","0", "nothing"},
			new List<string> { "In Deathmatch you get questions from all Categories. The game continues as long as you answer correctly.","0", "nothing"},
            new List<string> { "This is the score. It will increase the more questions you answer correctly.","0","Score"},
            new List<string> { "If you play in Category playmode, the Progress display shows how many questions you answered so far.","0", "Progress"},
            new List<string> { "After the game ends, you will be shown how you performed. Depending on your Score, you will get assigned a rank.","0","nothing"},
            new List<string> { "In the Statistics Menu you can see your Highscore, your highest ranks and in which categories you answered every question correctly at least once.","0","nothing"},
            //new List<string> { "And here could come more instructions.","0","nothing"},
			new List<string> { "Now you already know everything you need to know. Please go back to the Main Menu by pressing 'X'.","0", "nothing"},
		};
	}


	// wird jedes mal aufgerufen wenn instruction weiter oder zurück gemacht werden.
	// könnte genutzt werden um für jeden schritt funktionen zu enablen (zb bei "Answers" muss man klicken, dann kann man erst auf 'Next')
	public void updateInstructionColor(){
		if(instructions[instructionIndex][2] == "X"){
			Close.image.color = highlightColor;
		}
		else if(instructions[instructionIndex][2] == "Question"){
			questionButton.image.color = highlightColor;
		}
		else if(instructions[instructionIndex][2] == "Answers"){
			LowerLeft.image.color = highlightColor;
			LowerRight.image.color = highlightColor;
			UpperLeft.image.color = highlightColor;
			UpperRight.image.color = highlightColor;
		}
		else if(instructions[instructionIndex][2] == "Score"){
			Score.image.color = highlightColor;
		}
		else if(instructions[instructionIndex][2] == "Progress"){
			Progress.image.color = highlightColor;
		}
		else if (instructions[instructionIndex][2] == "AnswerColors"){
			LowerRight.image.color = Color.red;
			UpperLeft.image.color = Color.green;
		}
		else{
			print("nothing to highlight red");
		}
	}


	void OnEnable() {

		// safe current buttonColor
		print("OnEnable: now get colors?");
		float r = questionButton.image.color.r;
		float b = questionButton.image.color.g;
		float g = questionButton.image.color.b;
		float a = questionButton.image.color.a;
		normalColor = new Color(r,g,b,a);

		if(normalColor.r == 1f && normalColor.g == 0 && normalColor.b == 0 && normalColor.a == 1f){
			print("rot!");
			highlightColor = new Color(1f,1f,1f,1f);
		}

		// set Colors of Tutorial in case someone changed the button colors (always all buttons are changed)
		instructionFieldButton.image.color = instructionColor;
		next.image.color = instructionColor;
		back.image.color = instructionColor;

		// display first instruction
		instructionField.transform.GetChild(0).GetComponent<Text>().text = instructions[instructionIndex][0];

        //instructionIndex = -1;
		//nextInstruction();
    }


	public void lastInstruction(){
		setBackColors();
		if(instructionIndex == 0){
			// do nothing if already first question, cannot go back further
		}
		else{
			instructionIndex--;
			setInstructionField();
			instructionField.transform.GetChild(0).GetComponent<Text>().text = instructions[instructionIndex][0];

			// mark corresponding GameObject with instructionColor
			updateInstructionColor();
		}
	}


	public void nextInstruction(){
		setBackColors();
		if (instructionIndex == instructions.Count-1){
			print("end of tutorial");
		}
		else{
			print(instructionIndex);
			instructionIndex++;
			setInstructionField();

			// show correct instruction text
			instructionField.transform.GetChild(0).GetComponent<Text>().text = instructions[instructionIndex][0];

			// mark corresponding GameObject with instructionColor
			updateInstructionColor();
		}
	}


	public void setInstructionField(){
		// enable correct instruction field
		if (instructions[instructionIndex][1] == "0"){
			instructionField.transform.position = instructionPlace1.transform.position;
		}
		else{
			instructionField.transform.position = instructionPlace2.transform.position;
		}
	}


	public void setBackColors(){
		Close.image.color = normalColor;
		LowerLeft.image.color = normalColor;
		LowerRight.image.color = normalColor;
		UpperLeft.image.color = normalColor;
		UpperRight.image.color = normalColor;
		//Question.image.color = normalColor;
		questionButton.image.color = normalColor;
		//Answer.image.color = normalColor;
		Score.image.color = normalColor;
		Progress.image.color = normalColor;
	}
}
