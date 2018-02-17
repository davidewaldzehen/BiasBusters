using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsHandler : MonoBehaviour {

    public GameObject background;
    public GameObject mainMenuCanvas;
    public GameObject optionsCanvas;
    public GameObject colors;
    public Color colour;
    public Color defaultBackgroundColor;
    public Color defaultTextColor;
    public Color defaultButtonColor;
    public int toColor; // 2: button color, 1: background color, 0: text color
    public Text[] texts;
    public Button[] buttons;
    public GameObject quizGame;
	public Color textColor;
	public Color buttonColor;
	public Color backgroundColor;

    void Start()
    {
        quizGame = GameObject.Find("Quiz Game");
        texts = quizGame.GetComponent<GetTypes>().texts;
        buttons = quizGame.GetComponent<GetTypes>().buttons;
        //originalScale = canvases.transform.localScale;
        defaultBackgroundColor = background.GetComponent<Renderer>().material.color;
        defaultTextColor = new Color(0.2f, 0.2f, 0.2f, 1);
        defaultButtonColor = buttons[1].image.color;
		buttonColor = defaultButtonColor;
		print(buttonColor);
    }

    public void buttonColour()
    {
        toColor = 2;
        colors.gameObject.SetActive(true);
    }

    public void hintergrundFarbe()
    {
        toColor = 1;
        colors.gameObject.SetActive(true);
    }

    public void schriftFarbe()
    {
        toColor = 0;
        colors.gameObject.SetActive(true);
    }

    public void redCol()
    {
        colour = new Color(1, 0, 0, 1);
        if (toColor == 1)
        {
            print("should paint");
            background.GetComponent<Renderer>().material.color = colour;
			backgroundColor = colour;
        }
        else if (toColor == 0)
        {
            setTextColor(colour);
			textColor = colour;
        }
        else if (toColor == 2)
        {
            setButtonColour(colour);
			buttonColor = colour;
        }
    }

    public void yellowCol()
    {
        colour = new Color(1, 0.92f, 0.016f, 1);
        if (toColor == 1)
        {
            background.GetComponent<Renderer>().material.color = colour;
			backgroundColor = colour;
        }
        else if (toColor == 0)
        {
            setTextColor(colour);
			textColor = colour;
        }
        else if (toColor == 2)
        {
            setButtonColour(colour);
			buttonColor = colour;
        }
    }

    public void greenCol()
    {
        colour = new Color(0, 1, 0, 1);
        if (toColor == 1)
        {
            background.GetComponent<Renderer>().material.color = colour;
			backgroundColor = colour;
        }
        else if (toColor == 0)
        {
            setTextColor(colour);
			textColor = colour;
        }
        else if (toColor == 2)
        {
            setButtonColour(colour);
			buttonColor = colour;
        }
    }
    public void blueCol()
    {
        colour = new Color(0, 0.5f, 1, 1);
        if (toColor == 1)
        {
            background.GetComponent<Renderer>().material.color = colour;
			backgroundColor = colour;
        }
        else if (toColor == 0)
        {
            setTextColor(colour);
			textColor = colour;
        }
        else if (toColor == 2)
        {
            setButtonColour(colour);
			buttonColor = colour;
        }
    }
    public void orangeCol()
    {
        colour = new Color(1,0.5f,0,1);
        if (toColor == 1)
        {
            background.GetComponent<Renderer>().material.color = colour;
			backgroundColor = colour;
        }
        else if (toColor == 0)
        {
            setTextColor(colour);
			textColor = colour;
        }
        else if (toColor == 2)
        {
            setButtonColour(colour);
			buttonColor = colour;
        }
    }

    public void violetCol()
    {
        colour = new Color(1,0,1,1);
        if (toColor == 1)
        {
            background.GetComponent<Renderer>().material.color = colour;
			backgroundColor = colour;
        }
        else if (toColor == 0)
        {
            setTextColor(colour);
			textColor = colour;
        }
        else if (toColor == 2)
        {
            setButtonColour(colour);
			buttonColor = colour;
        }
    }

    public void blackCol()
    {
        colour = new Color(0, 0, 0, 1);
        if (toColor == 1)
        {
            background.GetComponent<Renderer>().material.color = colour;
			backgroundColor = colour;
        }
        else if (toColor == 0)
        {
            setTextColor(colour);
			textColor = colour;
        }
        else if (toColor == 2)
        {
            setButtonColour(colour);
			buttonColor = colour;
        }
    }

    public void defaultCol()
    {
        if (toColor == 1)
        {
            background.GetComponent<Renderer>().material.color = defaultBackgroundColor;
			backgroundColor = colour;
        }
        else if (toColor == 0)
        {
            setTextColor(defaultTextColor);
			textColor = colour;
        }
        else if (toColor == 2)
        {
            setButtonColour(defaultButtonColor);
			buttonColor = colour;
        }
    }

    public void back()
    {
        colors.gameObject.SetActive(false);
        optionsCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    }


    public void setTextColor(Color colour)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].color = colour;
            //print(texts[i].text);
        }
    }

    public void setButtonColour(Color colour)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].image.color = colour;
            //buttons[i].color = colour;
        }
    }
}
