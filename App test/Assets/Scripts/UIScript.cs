using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIScript : MonoBehaviour {
	
	public Button lowerleftButton;
	public Button upperleftButton;
	public Button lowerrightButton;
	public Button upperrightButton;
	public Button progressButton;
	public Button questionButton;

	public GameObject lowerleftText;
	public GameObject upperleftText;
	public GameObject lowerrightText;
	public GameObject upperrightText;
	public GameObject questionText;
	public GameObject progressText;

    public int playMode; // 0: Category, 1: Deathmatch, 2: Tutorial
    public int category; // -2: tutorial, -1: deathmatch, 0 = politicsEconomics, 1 = culture, 2 = society, 3 = environment, 4 = science
    public GameObject mainMenueCanvas;
	public GameObject GameOverCanvas;
    public GameObject quizUI;
	public GameObject lexiconEntries;
	public GameObject optionsCanvas;
	LexiconEntryHandler entryHandler;
	GameOver gameOverScript;
	public Button scoreButton;
	public Text scoreText;
	public GameObject sourcesCanvas;
	public Text sourcesText;
	public GameObject sourcesButton;
	public int score = 0;
	public int numCorrectAnswers = 0;

	bool incorrentColorShown = false;
	Color incorrectColor;
	Color defaultButtonColor;
	Color correctColor;
	public int questionsIndex;
	public string correctAnswer;
	public GameObject correct;
	public GameObject incorrect;
	public bool firstQuestion = true;
    public bool won = false;
	bool backFromLexicon = false;
	List<List<string>> questionsPoliticsEconomy;
	List<List<string>> questionsCulture;
	List<List<string>> questionsScience;
	List<List<string>> questionsSociety;
	List<List<string>> questionsEnvironment;
	List<List<string>> questionsTutorial;
	List<List<string>> temp;
	public List<List<string>> questions;
	public List<List<string>> questionsAll;
	public List<string> question;
    public List<int> usedQuestions = new List<int>();
	public List<List<int>> correctlyAnswered = new List<List<int>>();

	public List<List<int>> getCorrectlyAnswered(){
		return correctlyAnswered;
	}

	// aufbau eines eintrags: (alles strings)
	// [0]: Frage, [1]: antwort1, [2]: antwort2, [3]: antwort3, [4]: antwort4, [5]: richtige antwort, [6]: link von antwort1, [7]: link von antwort2, [8]: link von antwort3, [9]: link von antwort4
    public void initQuestionPools(){
		

		correctlyAnswered = new List<List<int>>{ };
		correctlyAnswered.Add(new List<int> {});
		correctlyAnswered.Add(new List<int> {});
		correctlyAnswered.Add(new List<int> {});
		correctlyAnswered.Add(new List<int> {});
		correctlyAnswered.Add(new List<int> {});
			

		questions = new List<List<string>>{
			//new List<string> { "a? ?", "Erneut elf Menschen in der Ägäis ertrunken", "Camper von Sturmflut überrascht und ertrunken", "Renate F., 34, im Urlaub mit einem Messer verletzt", "Prinzessin Diana tragisch verunglückt", "3"},
			//new List<string> { "b?", "7","16","27","34","2"},
			//new List<string> { "c", "pizza","pommes","schnitzel","purer knoblauch","0"},
			//new List<string> { "d ?", "Base Rate Fallacy","Conjunction Fallacy","Belief Bias","Humor Effect","1"},
            //new List<string> { "e?", "Ja","Nein","Vielleicht","Ich mag Toastbrot","3"},
			//new List<string> { },
		};

        //0 = politicsEconomics, 1 = culture, 2 = society, 3 = environment, 4 = science
        // 35 stück
        questionsPoliticsEconomy = new List<List<string>>{
			new List<string> { "Which of the following is more likely?", "", "", "The next president of the USA will have political experience and a nice character.", "The next president of the USA will have political experience.", "4" , "", "", "Conjunction Fallacy", "Conjunction Fallacy", "0",""},
			new List<string> { "German DAX at peak, Dow Jones relatively constant over the last few weeks", "Gamblers Fallacy", "Contrast effect", "Confirmation Bias", "Bizarreness Effect", "2" , "Gamblers Fallacy", "Contrast effect", "Confirmation Bias", "Bizarreness Effect", "0",""},
			new List<string> { "Populist Leader First Casualty of New German Law Censoring Free Speech", "Belief Bias", "Stereotyping", "Ingroup Bias", "Contrast Effect", "4" , "Belief Bias", "Stereotyping", "Ingroup Bias", "Contrast Effect", "0","www.breitbart.com"},
			new List<string> { "Trump’s Labor Law Enforcer Freezes Worker-Friendly Reforms Made Under Obama", "Illusory Truth Effect", "Contrast effect", "Stereotyping", "Humor Effect", "2" , "Illusory Truth Effect", "Contrast effect", "Stereotyping", "Humor Effect", "0","www.huffingtonpost.com"},
			new List<string> { "Donald Trump Taunts Kim Jong Un: My Nuclear Button Is ‘Bigger’", "Outcome Bias", "Authority Bias", "Contrast effect", "Availability Heuristic", "3" , "Outcome Bias", "Authority Bias", "Contrast effect", "Availability Heuristic", "0","www.huffingtonpost.com"},
			new List<string> { "USA Today Blames ‘Right Wing Nationalist Movements’ for Growing Anti-Semitism Driven by Migrant Crisis", "Framing Effect", "Availability Heuristic", "Illusory Truth Effect", "Declinism", "1" , "Framing Effect", "Availability Heuristic", "Illusory Truth Effect", "Declinism", "0", "www.breitbart.com"},
			new List<string> { "Trump Drinks Water Like Small Child During Big Speech", "Illusory Truth Effect", "Gamblers Fallacy", "Forer Effect", "Framing Effect", "4" , "Illusory Truth Effect", "Gamblers Fallacy", "Forer Effect", "Framing Effect", "0","www.huffingtonpost.com"},
			new List<string> { "Here Comes Another Effort To Undermine Obamacare’s Rules For Health Insurance", "Declinism", "Rhyme as Reason Effect", "Framing Effect", "Ingroup Bias", "3" , "Declinism", "Rhyme as Reason Effect", "Framing Effect", "Ingroup Bias", "0","www.huffingtonpost.com"},
			new List<string> { "Amazon Temp Workers Who Deliver The Holidays Are Getting Squeezed", "Identifiable victim", "Authority Bias", "Conjunction Fallacy", "Forer Effect", "1" , "Identifiable victim", "Authority Bias", "Conjunction Fallacy", "Forer Effect", "0","www.huffingtonpost.com"},
			new List<string> { "‘Father Of The Internet’ Skewers FCC: ‘You Don’t Understand How The Internet Works’", "Bizarreness Effect", "Halo Effect", "Conjunction Fallacy", "Just-World Hypothesis", "2" , "Bizarreness Effect", "Halo Effect", "Conjunction Fallacy", "Just-World Hypothesis", "0","www.huffingtonpost.com"},
			new List<string> { "Politician to be re-elected for the 214th time", "Forer Effect", "Rhyme as Reason Effect", "Bizarreness Effect", "Authority Bias", "3" , "Forer Effect", "Rhyme as Reason Effect", "Bizarreness Effect", "Authority Bias", "0",""},
			new List<string> { "Someone Just Won A Virginia Election After His Name Was Picked Out Of A Bowl", "Availability Heuristic", "Bizarreness Effect", "Authority Bias", "Rhyme as Reason Effect", "2" , "Availability Heuristic", "Bizarreness Effect", "Authority Bias", "Rhyme as Reason Effect", "0","www.buzzfeed.com"},
			new List<string> { "Casinos have installed facial recognition software in order to identify known frauds upon entering the premises. The software is 99% accurate. Let’s suppose 1 out of 1000 gamblers are known frauds. If an alarm goes off, what are the chances it correctly identified one of them?", "1%", "99%", "10%", "60%", "1" , "Base Rate Fallacy", "Base Rate Fallacy", "Base Rate Fallacy", "Base Rate Fallacy", "0",""},
			new List<string> { "1) All refugees receive social welfare benefits. 2) Some people who receive social welfare benefits abuse the welfare system. Therefore, some refugees abuse the welfare system. Does this conclusion follow from the premises?", "", "", "Yes", "No", "4" , "", "", "Belief Bias", "Belief Bias", "0",""},
			new List<string> { "Homelessness among veterans is often self-inflicted. Should the government even provide financial aid?", "Conjunction Fallacy", "Naive Realism", "Just-World Hypothesis", "Confirmation Bias", "3" , "Conjunction Fallacy", "Naive Realism", "Just-World Hypothesis", "Confirmation Bias", "0",""},
			new List<string> { "Sessions Says to Courts: Go Ahead, Jail People Because They're Poor", "Just-World Hypothesis", "Forer Effect", "Anchoring", "Halo Effect", "1" , "Just-World Hypothesis", "Forer Effect", "Anchoring", "Halo Effect", "0","www.nytimes.com"},
			new List<string> { "Pew: Trump media coverage three times more negative than Obama’s", "Naive Realism", "Authority Bias", "Declinism", "Belief Bias", "1" ,"Naive Realism", "Authority Bias", "Declinism", "Belief Bias", "0","www.foxnews.com"},
			new List<string> { "Picking Apples on a New York Farm With 5,000 Rules. How many apple farms are approximately located in New York?", "4,763", "694", "185", "1,644 ", "1" , "Anchoring", "", "", "", "0", "www.nytimes.com"},
			new List<string> { "Billionaire to Spend $30 Million on 2018 Elections. His Aim: Impeach Trump. How much money did Donald Trump’s election campaign rise?", "$102 Million", "$334 Million", "623 Million", "$38Million ", "4" , "", "", "", "Anchoring", "0", "www.nytimes.com"},
			new List<string> { "North Korea was behind crippling cyberattack on the US, White House officials say", "Ingroup Bias", "Authority Bias", "Identifiable Victim Effect", "Naive Realism", "2" , " Ingroup Bias ", " Authority Bias ", " Identifiable Victim Effect ", " Naive Realism ", "0","www.foxnews.com"},
			new List<string> { "ISIS has lost 98 percent of its territory -- mostly since Trump took office, officials say", "Naive Realism", "Base Rate Fallacy", "Authority Bias ", "Belief Bias", "3", "Naive Realism", "Base Rate Fallacy", "Authority Bias ", "Belief Bias", "0","www.foxnews.com"},
			new List<string> { "Net Neutrality’s Holes in Europe May Offer Peek at Future in U.S.", "Declinism", "Rhyme as Reason Effect", "Halo Effect", "Stereotyping", "1", "Declinism", "Rhyme as Reason Effect", "Halo Effect", "Stereotyping", "0", "www.nytimes.com"},
			new List<string> { "You thought 2017 was a wild ride? Brace for 2018", "Rhyme as Reason Effect", "Naive Realism", "Anchoring", "Declinism", "4", "Rhyme as Reason Effect", "Naive Realism", "Anchoring", "Declinism", "0", "www.cnn.com"},
			new List<string> { "The Student Loan Default Crisis Is Only Going To Get Worse, Report Finds", "Anchoring", "Conjunction Fallacy", "System Justification", "Declinism", "4" , "Anchoring", "Conjunction Fallacy", "System Justification", "Declinism", "0", "www.buzzfeed.com"},
			new List<string> { "For Trump, a year of reinventing the presidency", "Humor Effect", "Outcome Bias", "Halo Effect", "Contrast Effect", "1" , "Humor Effect", "Outcome Bias", "Halo Effect", "Contrast Effect", "0", "www.nytimes.com"},
			new List<string> { "Bitcoin Regrets: How Much $100 Would Be Worth Today if You Invested Earlier", "Declinism", "Contrast Effect", "Outcome Bias", "Naive Realism", "3" , "Declinism", "Contrast Effect", "Outcome Bias", "Naive Realism", "0","www.fortune.com"},
			new List<string> { "Fiat Chrysler to Recall 1.8 Million Ram Trucks Over Rollaways. How many vehicles are sold by Fiat Chrysler in the US in December 2016?", "957.298", "1.23 Million", "156.060", "12.172", "3" , "", "", "Anchoring", "", "0", "www.nytimes.com"},
			new List<string> { "Frustrated U.S. Might Withhold $255 Million in Aid From Pakistan. How high is the Pakistani gross domestic product?", "$284 Million", "$304 Billion", "$963 Million", "$86 Billion", "1" , "Anchoring", "", "", "", "0", "www.huffingtonpost.com"},
			new List<string> { "Bitcoin: What big names are saying", "Just-World Hypothesis", "Authority Bias", "Contrast Effect", "Declinism", "2",  "Just-World Hypothesis", "Authority Bias", "Contrast Effect", "Declinism", "0","www.cnn.com"},
			new List<string> { "The global economy is doing great ... for now", "Declinism", "Outcome Bias", "Gamblers Fallacy", "Illusion of Validity", "1", "Declinism", "Outcome Bias", "Gamblers Fallacy", "Illusion of Validity", "0", "www.cnn.com"},
			new List<string> { "How Tech Expanded from Silicon Valley to Bubblegum Alley", "Ingroup Bias", "Stereotyping", "Illusory Truth Effect", "Humor Effect", "4", "Ingroup Bias", "Stereotyping", "Illusory Truth Effect", "Humor Effect", "0", "www.nytimes.com"},
			new List<string> { "'Today refugees, tomorrow terrorists': Eastern Europeans chant anti-Islam slogans in demonstrations against refugees ", "Stereotyping", "Anchoring", "3","Conjunction Fallacy", "Outcome Bias", "Stereotyping", "Anchoring", "0","www.independent.co.uk"}, 
			new List<string> { "„What's a feminist?“ Farage says he's not a feminist because NO man can support feminism", "Ingroup Bias", "Outcome Bias", "Declinism", "Naive Realism", "1" , " Ingroup Bias ", " Outcome Bias", " Declinism ", " Naive Realism ", "0","www.thesun.co.uk"},
			new List<string> { "Putin says US list targets all Russians- What bias is Putin using?", "Ingroup Bias", "Availability Heuristic", "Illusory Truth Effect", "Declinism", "1" , "Ingroup Bias", "Availability Heuristic", "Illusory Truth Effect", "Declinism", "0", "www.bbc.com"},
			new List<string> { "Why a Congress controlled by Democrats would be bad (really bad) for America", "Outcome Bias", "Contrast Effect", "Conjunction Fallacy", "System Justification", "4" ,"Outcome Bias", "Contrast Effect", "Conjunction Fallacy", "System Justification", "0","www.foxnews.com"},
			};

			// 20 stück 5 definitionen
		questionsCulture = new List<List<string>>{ 
			new List<string> { "How western civilisation could collapse", "Outcome Bias", "Base Rate Fallcy", "Declinism", "Illusory Truth Effect", "3", "Outcome Bias", "Base Rate Fallacy", "Declinism", "Illusory Truth Effect", "1", "www.bbc.com"},
new List<string> { "The new American hit single is out. Which of the following is more likely?", "", "", "It is on the first place of the German music charts.", "It is on the first place in the American and German music charts.", "3" , "", "", "Conjunction Fallacy", "Conjunction Fallacy", "1",""},
new List<string> { "The next Academy Award for best picture will most likely…", "", "", "go to a movie with a great plot and amazing camera effects.", "go to a movie with amazing camera effects.", "4" , "", "", "Conjunction Fallacy", "Conjunction Fallacy", "1",""},
new List<string> { "NYT Lauds ‘Mercy’ of NYC Bomber, Hails ‘Army of Darkness’ Group as ‘Peaceful Muslim Outreach Org’ ", "Conjunction Fallacy", "Contrast effect", "Declinism", "Anchoring", "2" , "Conjunction Fallacy", "Contrast effect", "Declinism", "Anchoring", "1","www.breitbart.com"},
new List<string> { "James Franco Blocks Tommy Wiseau From Finally Getting His Golden Globes Moment", "Stereotyping", "Gamblers Fallacy", "Contrast effect", "Illusion of Validity", "3" , "Stereotyping", "Gamblers Fallacy", "Contrast effect", "Illusion of Validity", "1","www.huffingtonpost.com"},
new List<string> { "Oscars: Leonardo DiCaprio finally wins an Academy Award", "Humor Effect", "Identifiable victim", "Base Rate Fallacy", "Stereotyping", "2" , "Humor Effect", "Identifiable victim", "Base Rate Fallacy", "Stereotyping", "1","www.abc.net.au"},
new List<string> { "Oscar winning director starts work on new masterpiece.", "Availability Cascade", "Rhyme as Reason Effect", "Halo Effect", "Just-World Hypothesis", "3" , "Availability Cascade", "Rhyme as Reason Effect", "Halo Effect", "Just-World Hypothesis", "1",""},
new List<string> { "People Want Oprah To Run For President After Her Powerful Golden Globes Speech", "Halo Effect", "Rhyme as Reason Effect", "Contrast Effect", "Humor Effect", "1" , "Halo Effect", "Rhyme as Reason Effect", "Contrast Effect", "Humor Effect", "1","www.huffingtonpost.com"},
new List<string> { "1) If actors star in Hollywood movies, they earn a lot of money. 2) Some actors do not star in Hollywood movies. Therefore, some actors do not earn a lot of money. Does this conclusion follow from the premises?", "", "", "Yes", "No", "4", "", "", "Belief Bias", "Belief Bias", "1",""},
new List<string> { "’The best decision of my life’: Producer and director of hit movie reveals that she risked financial ruin to produce her movie independently, but feels it has all paid off now", "Declinism", "Outcome Bias", "Just-World Hypothesis", "Contrast Effect", "2" , "Declinism", "Outcome Bias", "Just-World Hypothesis", "Contrast Effect", "1",""},
new List<string> { "Review: New Broadway play is clearly designed to please the ignorant masses, relies heavily on overplayed ideas and storylines.", "Contrast Effect", "Naive Realism", "Anchoring", "Outcome Bias", "2" ,"Contrast Effect", "Naive Realism", "Anchoring", "Outcome Bias", "1",""},
new List<string> { "Giant monkey wins dance-off in the suburbs", "Conjunction Fallacy", "Forer Effect", "Availability Cascade", "Bizarreness effect", "4" , "Conjunction Fallacy", "Forer Effect", "Availability Cascade", "Bizarreness effect", "1",""},
new List<string> { "Anna is applying to the top international ballet school that accepts only 3% of its applicants. She has been taking classes since she was 5. At her dance school, she is the star ballerina and her teachers see high potential in her. Is it likely that she will get accepted?", "", "", "No", "Yes", "3" , "", "", "Base Rate Fallacy", "Base Rate Fallacy", "1",""},
new List<string> { "Angela Lansbury: Women ‘must sometimes take blame’ for harassment", "Identifiable Victim Effect", "Just-World Hypothesis", "Anchoring", "Authority Bias", "2" , "Identifiable Victim Effect", "Just-World Hypothesis", "Anchoring", "Authority Bias", "1","www.radiotimes.com"},
new List<string> { "Your star-wars loving child might be a Jedi", "Humor Effect", "Belief Bias", "Halo Effect", "Rhyme as Reason Effect", "1", "Humor Effect", "Belief Bias", "Halo Effect", "Rhyme as Reason Effect", "1", "www.usatoday.com"},
new List<string> { "'He began to eat Hermione's family': bot tries to write Harry Potter book – and fails in magic ways", "Halo Effect", "Anchoring", "Humor Effect", "Base Rate Fallacy", "3", "Halo Effect", "Anchoring", "Humor Effect", "Base Rate Fallacy", "1", "www.theguardian.com"},
new List<string> { "Monopoly ‘Cheater’s Edition’ Is Coming Because This Is The World We Live In", "Authority Bias", "Declinism", "Gamblers Fallacy", "System Justification", "2", "Authority Bias", "Declinism", "Gamblers Fallacy", "System Justification", "1", "www.huffingtonpost.com"},
new List<string> { "Why Italians are saying 'No' to takeaway coffee ", "Conjunction Fallacy", "Outcome Bias", "Stereotyping", "Anchoring", "3","Conjunction Fallacy", "Outcome Bias", "Stereotyping", "Anchoring", "1","www.bbc.com"},
new List<string> { "Celebrities host counter-event to State of the Union: Trump supporters are 'ugly underbelly' ", "Just-World Hypothesis", "Ingroup Bias", "Contrast effect", "Illusion of Validity", "2" , "Just-World Hypothesis", "Ingroup Bias", "Contrast effect", "Illusion of Validity", "1","www.foxnews.com"},
new List<string> { "BBC insists 'no evidence of gender bias' despite 6.8% pay gap between male and female presenters- in which way, BBC is biased?", "Availability Cascade", "System Justification", "Halo Effect", "Just-World Hypothesis", "2" , "Availability Cascade", "System Justification", "Halo Effect", "Just-World Hypothesis", "1","www.independent.co.uk"},
        
new List<string> { "Which bias does this refer to: [...] is adding or reducing value to subjects / objects, what we perceive & how we analyze them as compared to a normal case by comparing them to some other subject/object with good/bad attributes.", "Contrast Effect", "Illusory Truth Effect", "Illusion of Validity", "Ingroup Bias", "1" , "Contrast Effect", "Illusory Truth Effect", "Illusion of Validity", "Ingroup Bias", "2", ""},
new List<string> { "Which bias does this refer to: Drawing different conclusions from the same information, depending on how that information is presented.", "Authority Bias", "Confirmation Bias", "Framing Effect", "Conjunction Fallacy", "3" , "Authority Bias", "Confirmation Bias", "Framing Effect", "Conjunction Fallacy", "2", ""},
new List<string> { "Which bias does this refer to: We empathize with distinct individuals who are suffering far more than a large number of anonymous people.", "Conjunction Fallacy", "Identifiable Victim Effect", "Declinism", "Framing Effect", "2" , "Conjunction Fallacy", "Identifiable Victim Effect", "Declinism", "Framing Effect", "2", ""},
new List<string> { "Which bias does this refer to: a common bias, in the impression people form of others, by which attributes are often generalized (for example, clever people may falsely be assumed to be knowledgeable about everything).", "Bizarreness Effect", "Forer Effect", "Rosy Retrospection", "Halo Effect", "4" , "Bizarreness Effect", "Forer Effect", "Rosy Retrospection", "Halo Effect", "2", ""},
new List<string> { "Which bias does this refer to: The bias holds that items associated with bizarre sentences or phrases are more readily recalled than those associated with common sentences or phrases.", "Bizarreness Effect", "Belief Bias", "Just-World Hypothesis", "Availability Cascade", "1" , "Bizarreness Effect", "Belief Bias", "Just-World Hypothesis", "Availability Cascade", "1", ""},

		};

		// 15 stück + 10 definitionen
		questionsScience = new List<List<string>>{ 
			new List<string> { "Global warming is caused by methane produced by cows rather than methane in general. Is this statement true or false?", "", "", "False", "True", "3" , "", "", "Conjunction Fallacy", "Conjunction Fallacy", "4",""},
new List<string> { "The next person you meet is most likely…", "", "", "human.", "a nice human.", "3" , "", "", "Conjunction Fallacy", "Conjunction Fallacy", "4",""},
new List<string> { "R.S.V.? She Hadn’t Heard of It. Then Her Child Was Hospitalized.", "Identifiable victim", "Rhyme as Reason Effect", "Ingroup Bias", "Base Rate Fallacy", "1" , "Identifiable victim", "Rhyme as Reason Effect", "Ingroup Bias", "Base Rate Fallacy", "4","www.nytimes.com"},
new List<string> { "Would you assume that it is also likely that the Physics Nobel prize winner would win a cooking contest?", "", "", "Yes", "No", "4" , "", "", "Halo Effect", "Halo Effect", "4",""},
new List<string> { "Big environmental protection NGO releases new electrical car", "Rhyme as Reason Effect", "Illusory Truth Effect", "Halo Effect", "Availability Heuristic", "3" , "Rhyme as Reason Effect", "Illusory Truth Effect", "Halo Effect", "Availability Heuristic", "4",""},
new List<string> { "The Invisible Underwater Messaging System in Blue Crab Urine", "Authority Bias", "Halo Effect", "Confirmation Bias", "Bizarreness Effect", "4" , "Authority Bias", "Halo Effect", "Confirmation Bias", "Bizarreness Effect", "4","www.nytimes.com"},
new List<string> { "Loud orgies of Mexican fish could deafen dolphins, say scientists", "Availability Heuristic", "Base Rate Fallacy", "Outcome Bias", "Bizarreness Effect", "4" , "Availability Heuristic", "Base Rate Fallacy", "Outcome Bias", "Bizarreness Effect", "4","www.theguardian.com"},
new List<string> { "“Birth control still linked to cancer, study says”: Taking hormonal birth control increases the risk of breast cancer by 20%. Who is more likely to develop breast cancer?", "", "", "A 20 year-old woman who is taking hormonal birth control", "A 30 year-old woman who has never been on hormonal birth control", "4" , "", "", "Base Rate Fallacy", "Base Rate Fallacy", "4","www.nytimes.com"},
new List<string> { "1) Some studies in social psychology could not be replicated. 2) Some replication failures occurred, because the original statistical analyses were flawed. Therefore, some studies in social psychology used flawed statistical analyses. Does this conclusion follow from the premises?", "", "", "Yes", "No", "4" , "", "", "Belief Bias", "Belief Bias", "4",""},
new List<string> { "One patient died this week while undergoing an experimental brain  surgery. Now people are questioning whether the procedure should have ever been allowed", "Outcome Bias", "Contrast Effect", "Conjunction Fallacy", "Declinism", "1" ,"Outcome Bias", "Contrast Effect", "Conjunction Fallacy", "Declinism", "4",""},
new List<string> { "New evidence: studies on the dangers of vaccines are suppressed so that big pharma can keep making money", "Forer Effect", "Authority Bias", "Naive Realism", "System Justification", "3" ,"Forer Effect", "Authority Bias", "Naive Realism", "System Justification", "4",""},
new List<string> { "E.P.A. Wanted Years to Study Lead Paint Rule. It Got 90 Days. When did the first Lead Paint Rule become effective?", "1951", "1993", "2010", "this year", "2" , "", "Anchoring", "", "", "4", "www.nytimes.com"},
new List<string> { "‘Fake News’: Wide Reach but Little Impact, Study Suggests", "Humor Effect", "Illusion of Vailidity", "Authority Bias", "Stereotyping", "3", "Humor Effect", "Illusion of Vailidity", "Authority Bias", "Stereotyping", "4","www.nytimes.com"},
new List<string> { "If We Ever Get to Mars, the Beer Might Not Be Bad", "Contrast Effect", "Illusion of Validity", "Authority Bias", "Humor Effect", "4","Contrast Effect", "Illusion of Validity", "Authority Bias", "Humor Effect", "4","www.nytimes.com"},
new List<string> { "Thanks to Blockchain, You Can See What Your Thanksgiving Turkey Looked Like As A Child", "Bizarreness Effect", "Ingroup Bias", "Halo Effect","Gamblers Fallacy",  "1" ,"Bizarreness Effect", "Ingroup Bias", "Halo Effect","Gamblers Fallacy", "4","www.buzzfeed.com"},

new List<string> { "The tendency to remember some content better, because it elicits certain emotions and have to be cognitively processed, is called", "Base Rate Fallacy", "Illusion of Validity", "Halo Effect", "Humor Effect", "3" , "Base Rate Fallacy", "Illusion of Validity", "Halo Effect", "Humor Effect", "4",""},
new List<string> { "Which bias does this refer to: The tendency of  ‘rosy retrospection’, meaning that circumstances are perceived to decline in comparison with past conditions.", "Framing Effect", "Naive Realism", "Declinism", "Just-World Hypothesis", "3" , "Framing Effect", "Naive Realism", "Declinism", "Just-World Hypothesis", "4",""},
new List<string> { "The tendency to attribute higher accuracy to informations given or confirmed by authorities, is called", "Authority Bias", "Halo Effect", "Base Rate Fallacy", "Humor Effect", "1" , "Authority Bias", "Halo Effect", "Base Rate Fallacy", "Humor Effect", "4",""},
new List<string> { "The tendency to infer an estimation of quantitative sort from another related or random number is called", "System Justification", "Just-World Hypothesis", "Anchoring", "Illusory Truth Effect", "3" , "System Justification", "Just-World Hypothesis", "Anchoring", "Illusory Truth Effect", "4", ""},
new List<string> { "Which bias does this refer to: The tendency to see ourselves as someone who sees the world objectively, whereas those who do not agree with our views must be ignorant, uninformed, or biased.", "Contrast Effect", "Illusory Truth Effect", "Framing Effect", "Naive Realism", "4" ,"Contrast Effect", "Illusory Truth Effect", "Framing Effect", "Naive Realism", "4",""},
new List<string> { "Which bias does this refer to: The belief that the world is fair and all actions will eventually lead to the deserved outcome.", "Belief Bias", "Confirmation Bias", "Illusory Truth Effect", "Just-World Hypothesis", "4" ,"Belief Bias", "Confirmation Bias", "Illusory Truth Effect", "Just-World Hypothesis", "4",""},
new List<string> { "Which bias does this refer to: The tendency to judge the quality of a choice in the past based on its final outcome.", "Outcome Bias", "Contrast Effect", "Confirmation Bias", "Forer Effect", "1" ,"Outcome Bias", "Contrast Effect", "Confirmation Bias", "Forer Effect", "4",""},
new List<string> { "Which bias does this refer to: The tendency to judge the truth of an argument by the plausibility of its conclusion rather than by the ability to derive said conclusions through its premises.", "Belief Bias", "Outcome Bias", "Anchoring", "Framing Effect", "1" , "Belief Bias", "Outcome Bias", "Anchoring", "Framing Effect", "4",""},
new List<string> { "Which bias does this refer to: The tendency to ignore information about the base rate of events when judging the conditional probability of the event", "Belief Bias", "Base Rate Fallacy", "Conjunction Fallacy", "Contrast Effect", "2" , "Belief Bias", "Base Rate Fallacy", "Conjunction Fallacy", "Contrast Effect", "4",""},
new List<string> { "Which bias does this refer to: A widespread error of judgement according to which a combination of two or more attributes is judged to be more probable or likely than either attribute on its own.", "Framing Effect", "Conjunction Fallacy", "Identifiable Victim Effect", "Humor Effect", "2" , "Framing Effect", "Conjunction Fallacy", "Identifiable Victim Effect", "Humor Effect", "4",""},
		};

		// 27 stück
		questionsSociety = new List<List<string>>{
			new List<string> { "Paul E. is supporting animal rights, studied law and lives in New York. Which of the following is more likely?", "", "", "He is a judge and a Greenpeace activist.", "He is a judge.", "4" , "", "", "Conjunction Fallacy", "Conjunction Fallacy", "2",""},
new List<string> { "Local woman gets full custody over her children after husband kills a man", "Contrast effect", "Rhyme as Reason Effect", "Humor Effect", "Declinism", "1" , "Contrast effect", "Rhyme as Reason Effect", "Humor Effect", "Declinism", "2",""},
new List<string> { "British 15-year-old gained access to intelligence operations in Afghanistan and Iran by pretending to be head of CIA, court hears", "Framing Effect", "Forer Effect", "Outcome Bias", "Contrast Effect", "4" , "Framing Effect", "Forer Effect", "Outcome Bias", "Contrast Effect", "2","www.telegraph.co.uk"},
new List<string> { "Barack Obama Tweets Uplifting Local Stories To Remind Us What Went Right In 2017", "Availability Cascade", "Framing Effect", "Authority Bias", "Contrast Effect", "2" , "Availability Cascade", "Framing Effect", "Authority Bias", "Contrast Effect", "2","www.huffingtonpost.com"},
new List<string> { "Little Timmy, 9 years, falls in well", "Ingroup Bias", "Stereotyping", "Conjunction Fallacy", "Identifiable Victim Effect", "4" , "Ingroup Bias", "Stereotyping", "Conjunction Fallacy", "Identifiable Victim Effect", "2",""},
new List<string> { "‘Frost Boy’ in China Warms Up the Internet, and Stirs Poverty Debate", "System Justification", "Ingroup Bias", "Identifiable victim", "Bizarreness Effect", "X" , "System Justification", "Ingroup Bias", "Identifiable victim", "Bizarreness Effect", "2","www.nytimes.com"},
new List<string> { "92-year-old woman from local retirement home gets robbed in wheelchair", "Identifiable victim", "Outcome Bias", "Forer Effect", "Rhyme as Reason Effect", "1" , "Identifiable victim", "Outcome Bias", "Forer Effect", "Rhyme as Reason Effect", "2",""},
new List<string> { "Actors Who Say They Were Sexually Harassed By Talent Agents Aren't Ready To Forgive And Forget", "Gamblers Fallacy", "Identifiable victim", "Declinism", "Authority Bias", "2" , "Gamblers Fallacy", "Identifiable victim", "Declinism", "Authority Bias", "2","www.buzzfeed.com"},
new List<string> { "Man loses everything except his kitten after his house burns down", "Bizarreness Effect", "Declinism", "Identifiable victim", "Ingroup Bias", "3" , "Bizarreness Effect", "Declinism", "Identifiable victim", "Ingroup Bias", "2","www.metro.co.uk"},
new List<string> { "Barack Obama Shares His Favorite Books And Songs From 2017", "Naive Realism", "Stereotyping", "Identifiable Victim Effect", "Halo Effect", "4" , "Naive Realism", "Stereotyping", "Identifiable Victim Effect", "Halo Effect", "2","www.huffingtonpost.com"},
new List<string> { "Police Chief Charged With Trying To Solicit Sex From A 14-Year-Old Who Was Actually An Undercover Cop", "System Justification", "Bizarreness Effect", "Ingroup Bias", "Outcome Bias", "2" , "System Justification", "Bizarreness Effect", "Ingroup Bias", "Outcome Bias", "2","www.buzzfeed.com"},
new List<string> { "Black pudding saves butcher trapped in freezer", "Availability Cascade", "Bizarreness Effect", "Illusory Truth Effect", "Framing Effect", "2" , "Availability Cascade", "Bizarreness Effect", "Illusory Truth Effect", "Framing Effect", "2","www.bbc.com"},
new List<string> { "Tom is 30 years old, somewhat eccentric and very outgoing. He loves being the center of attention and dramatically recounting stories to his friends. Tom is most likely…", "", "", "a famous actor", " a computer scientist", "4" , "", "", "Base Rate Fallacy", "Base Rate Fallacy", "2",""},
new List<string> { "Hostages of bank robbery saved in heroic move by police officer", "Halo Effect", "Contrast Effect", "Identifiable Victim Effect", "Outcome Bias", "4" , "Halo Effect", "Contrast Effect", "Identifiable Victim Effect", "Outcome Bias", "2",""},
new List<string> { "Gabby Douglas says women should 'dress modestly' in response to sex abuse claims by Aly Raisman", "Belief Bias", "Contrast Effect", "Forer Effect", "Just-World Hypothesis", "4" , "Belief Bias", "Contrast Effect", "Forer Effect", "Just-World Hypothesis", "2","www.foxnews.com"},
new List<string> { "Obama warns on harmful social media use", "Illusory Truth Effect", "Anchoring", "Ingroup Bias", "Authority Bias ", "4" , "Illusory Truth Effect", "Anchoring", "Ingroup Bias", "Authority Bias ", "2","www.bbc.com"},
new List<string> { "Extremely wasteful for society': Professor says many students get nothing out of college", "Authority Bias", "Bizarreness Effect", "Conjunction Fallacy", " Framing Effect", "1", "Authority Bias", "Bizarreness Effect", "Conjunction Fallacy", " Framing Effect", "2","www.foxnews.com"},
new List<string> { "Papa John’s Gets Badly Burned In Twitter War With DiGiorno", "Authority Bias", "Outcome Bias", "Humor Effect", "Ingroup Bias", "3", "Authority Bias", "Outcome Bias", "Humor Effect", "Ingroup Bias", "2", "www.huffingtonpost.com"},
new List<string> { "Desperate Housewives actress Teri Hatcher signs up for celebrity series of The Great British Bake Off", "Humor Effect", "Forer Effect", "Stereotyping", "Anchoring", "1", "Humor Effect", "Forer Effect", "Stereotyping", "Anchoring", "2", "www.thesun.co.uk"},
new List<string> { "Topless protester tries to grab baby Jesus figure at Vatican", "Bizarreness Effect", "Base Rate Fallacy", "Humor Effect", "Contrast Effect", "3",  "Bizarreness Effect", "Base Rate Fallacy", "Humor Effect", "Contrast Effect", "2", "www.nytimes.com"},
new List<string> { "Let This ‘Baby-Sitters Club’ Reunion Stoke Your ‘90s Nostalgia Joy", "Declinism", "Just-World Hypothesis", "Bizarreness Effect", "Stereotyping", "1", "Declinism", "Just-World Hypothesis", "Bizarreness Effect", "Stereotyping", "2", "www.huffingtonpost.com"},
new List<string> { "A New York bar is literally kicking out customers for saying ‘literally.’", "Conjunction Fallacy", "Outcome Bias", "Humor Effect", "Anchoring", "3","Conjunction Fallacy", "Outcome Bias", "Humor Effect", "Anchoring", "2","www.washingtonpost.com"},
new List<string> { "CHIP AND SKIM: Boutique owner swindled £14k by giving herself fake refunds by chip and pin", "Illusion of Validity", "Gambler’s Fallacy", "Halo Effect", "Authority Bias", "2" , "Illusion of Validity", "Rhyme as Reason Effect", "Halo Effect", "Authority Bias", "2","www.thesun.co.uk"},
new List<string> { "BABY BOY JOY - Chrissy Teigen confirms she’s having a baby boy at the Grammys after     gender selection controversy ", "Framing Effect", "Bizarreness Effect", "Rhyme as Reason Effect", "Forer Effect", "3" , "Framing Effect", "Bizarreness Effect", "Rhyme as Reason Effect", "Forer Effect", "2","www.thesun.co.uk"},
new List<string> { "Hollywood Dream-Couple: After giving birth to 3 sons, it HAS to be a girl! - Wich Bias do you detect here?", "Illusion of Validity", "Gambler’s Fallacy", "Halo Effect", "Authority Bias", "4" , "Illusion of Validity", "Gamblers Fallacy", "Halo Effect", "Authority Bias", "2",""},
new List<string> { "You are in the casino and want to play roulette- the last 4 times, it was always black. What color should you place your bet on?", "RED- it can't be black again!", "BLACK- it’s the color of the day!", "BLACK – because it is my lucky color!", "It doesn't make a difference", "4" , "Gamblers Fallacy", "Gamblers Fallacy", "Gamblers Fallacy", "Gamblers Fallacy", "2",""},
//(related to the question before),
new List<string> { "Your color won! Now you are betting on a number. Within the last 10 games, it was 8 times the number 21.", "It's odd. I should rather wait for the security...", "then I chose the 21 again!", "Hm...not 21, this would be too lucky", "The odds are always the same, got you.", "4" , "Gamblers Fallacy", "Gamblers Fallacy", "Gamblers Fallacy", "Gamblers Fallacy", "2",""},
		};

		// 20 stück + 6 definitionen
		questionsEnvironment = new List<List<string>>{
			new List<string> { "You are more likely to be bitten by your neighbors dog than by dogs in general.", "", "", "False", "True", "3" , "", "", "Conjunction Fallacy", "Conjunction Fallacy", "3",""},
new List<string> { "While Everyone Else Was Hungover, These People Came Together To Save A Whale's Life On New Year's Day", "Belief Bias", "Identifiable Victim Effect", "Contrast effect", "Confirmation Bias", "3" , "Belief Bias", "Identifiable Victim Effect", "Contrast effect", "Confirmation Bias", "3","www.buzzfeed.com"},
new List<string> { "From Chocolate Famine to Desertification – How Alarmists Want to Ruin Your New Year", "Framing Effect", "Availability Heuristic", "Halo Effect", "Identifiable Victim Effect", "1" , "Framing Effect", "Availability Heuristic", "Halo Effect", "Identifiable Victim Effect", "3","www.breitbart.com"},
new List<string> { "Iguanas Are Freezing And Falling From Trees In Florida And The Northeast Has No Sympathy", "Illusion of Validity", "Authority Bias", "Gamblers Fallacy", "Identifiable victim", "4" , "Illusion of Validity", "Authority Bias", "Gamblers Fallacy", "Identifiable victim", "3","www.buzzfeed.com"},
new List<string> { "Baby sloth found crying and abandoned on beach", "Confirmation Bias", "Identifiable victim", "System Justification", "Illusory Truth Effect", "2" , "Confirmation Bias", "Identifiable victim", "System Justification", "Illusory Truth Effect", "3","www.metro.co.uk"},
new List<string> { "Multi-millionaire releases book about how to fish", "Availability Heuristic", "Halo Effect", "Stereotyping", "Illusion of Validity", "2" , "Availability Heuristic", "Halo Effect", "Stereotyping", "Illusion of Validity", "3",""},
new List<string> { "This Dog Actually Pulled A Sled Up A Hill And Then Rode It Down And What Is Happening", "Bizarreness Effect", "Gamblers Fallacy", "Illusory Truth Effect", "Rhyme as Reason Effect", "1" , "Bizarreness Effect", "Gamblers Fallacy", "Illusory Truth Effect", "Rhyme as Reason Effect", "3","www.buzzfeed.com"},
new List<string> { "1) If land-based ice masses melt, the sea levels will rise.2) The sea levels are rising. Therefore,land-based ice masses have melted. Does this conclusion follow from the premises?", "", "", "Yes", "No", "4" , "", "", "Belief Bias", "Belief Bias", "3",""},
new List<string> { "1) If GMOs are proven to be harmful to human health, they are not safe for consumption. 2) GMOs were found not to be harmful to human health.Therefore, GMOs are safe for consumption. Does this conclusion follow from the premises?", "", "", "Yes", "No", "4" , "", "", "Belief Bias", "Belief Bias", "3",""},
new List<string> { "Avoidable catastrophe: Security engineers should have acted earlier on environmental risks to nuclear power plant", "Outcome Bias", "Belief Bias", "Authority Bias", "Halo Effect", "1" , "Outcome Bias", "Belief Bias", "Authority Bias", "Halo Effect", "3",""},
new List<string> { "‘They knew they had built in flood-prone areas.’ Some people who lost their property in this year’s floods will not receive insurance money.", "Just-World Hypothesis", "Contrast Effect", "Illusory Truth Effect", "Belief Bias", "1" ,"Just-World Hypothesis", "Contrast Effect", "Illusory Truth Effect", "Belief Bias", "3",""},
new List<string> { "PROOF: CNN Knows Climate Change Is a Big Fat Hoax", "Belief Bias", "Naive Realism", "Illusory Truth Effect", "Contrast Effect", "2" ,"Belief Bias", "Naive Realism", "Illusory Truth Effect", "Contrast Effect", "3","www.dailywire.com"},
new List<string> { "Neutrality of scientific research on the risks associated with air pollution comes into question,  skeptics refer to a lack of ‘bodies’ killed by pollution", "Conjunction Fallacy", "Framing Effect", "Halo Effect", "Naive Realism", "4" ,"Conjunction Fallacy", "Framing Effect", "Halo Effect", "Naive Realism", "3",""},
new List<string> { "Researchers Warn of a Spreading Fungus Deadly to Snakes", "Authority Bias", "Belief Bias", "Gamblers Fallacy", "System Justification", "1" , "Authority Bias", "Belief Bias", "Gamblers Fallacy", "System Justification", "3","www.nytimes.com"},
new List<string> { "It’s Cold Outside. Cue the Trump Global Warming Tweet", "Illusion of Validity", "Humor Effect", "Identifiable Victim Effect", "Framing Effect", "2", "Illusion of Validity", "Humor Effect", "Identifiable Victim Effect", "Framing Effect", "3", "www.nytimes.com"},
new List<string> { "The bizarre beast with an air-conditioning nose", "Humor Effect", "Anchoring", "Naive Realism", "Gamblers Fallacy", "1", "Humor Effect", "Anchoring", "Naive Realism", "Gamblers Fallacy", "3", "www.bbc.com"},
new List<string> { "Some clownfish have no personality, Australian study finds", "Just-World Hypothesis", "Framing Effect", "Base Rate Fallacy", "Humor Effect", "4", "Just-World Hypothesis", "Framing Effect", "Base Rate Fallacy", "Humor Effect", "3", "www.theguardian.com"},
new List<string> { "Donald Trump's 'hatred of sharks' benefits conservation charities", "Contrast Effect", "Authority Bias", "Belief Bias", "Stereotyping", "1" , "Contrast Effect", "Authority Bias", "Belief Bias", "Stereotyping", "3","www.bbc.com"},
new List<string> { "Beer  before wine makes you feel fine. Wine before beer never have fear.", "", "", "TRUE", "FALSE", "4" , "", "", "Rhyme as Reason Effect", "Rhyme as Reason Effect", "3",""},
new List<string> { "Wine before beer I do endear; Beer before wine I do decline.", "", "", "TRUE", "FALSE", "4" , "", "", "Rhyme as Reason Effect", "Rhyme as Reason Effect", "3",""},
		
new List<string> { "How is the bias called that explains why people tend to believe that the (always identical) likelihood of a random event changes?", "Belief Bias", "Contrast Effect", "Ingroup Bias", "Gambler’s Fallacy", "4" , "Belief Bias", "Contrast Effect", "Ingroup Bias", "Gambler’s Fallacy", "3",""},
new List<string> { "When people get more secure about their prediction, although new input offers no new information, they fell for...", "System Justification", "Availability Cascade", "Illusion of Validity", "Illusory Truth Effect", "3" , "System Justification", "Availability Cascade", "Illusion of Validity", "Illusory Truth Effect", "3", ""},
new List<string> { "Which bias does this refer to: People tend to believe that the same statement is more accurate or truthful if it is formulated in a way that it rhymes", "Availability Heuristic", "Rhyme as Reason Effect", "Humor Effect", "Naive Realism", "2" ,"Availability Heuristic", "Rhyme as Reason Effect", "Humor Effect", "Naive Realism", "3",""},
new List<string> { "Which bias is about falsely assuming that people within a group are more similar than they actually are?", "Belief Bias", "Confirmation Bias", "Stereotyping", "Just-World Hypothesis", "3" ,"Belief Bias", "Confirmation Bias", "Stereotyping", "Just-World Hypothesis", "3",""},
new List<string> { "When fans shout at a refugee to penalize a foul that they ignored from their own team before, they are...", "Ingroup Biased", "Outcome Biased", "Confirmation Biased", "Authority Biased", "1" ,"Ingroup Bias", "Outcome Bias", "Confirmation Bias", "Authority Bias", "3",""},
new List<string> { "Which bias is sought after: The tendency to defend and justify the status quo simply because it exists", "Base Rate Bias", "Conjunction Bias", "Anchoring", "System Justification", "4" , "Base Rate Bias", "Conjunction Bias", "Anchoring", "System Justification", "3", ""},
		};

		questionsAll = questionsPoliticsEconomy.Concat(questionsCulture).Concat(questionsScience).Concat(questionsSociety).Concat(questionsEnvironment).Distinct().ToList();
	}

	// Use this for initialization
	void Start () {
        //usedQuestions = new int[20];
        entryHandler = lexiconEntries.GetComponent<LexiconEntryHandler>();
		correctColor = Color.green;
		incorrectColor = Color.red;
		gameOverScript = GameOverCanvas.GetComponent<GameOver>();
		
    }

	void OnEnable() {
		
		if(playMode == 1){
			progressButton.gameObject.SetActive(false);
		}
		defaultButtonColor = questionButton.image.color;

		// das hier nur machen, wenn das spiel neu gestartet ist, nicht wenn man aus dem lexikon zurück kommt
		if(backFromLexicon == false){
			stopDeathmatch = false;
			score = 0;
			numCorrectAnswers = 0;
			firstQuestion = true;
			displayNextQuestion();
		}
		else{
			backFromLexicon = false;
		}
    }
	
	// 0 = politicsEconomics, 1 = culture, 2 = society, 3 = environment, 4 = science
	public void setQuestionPool(){
		if(playMode == 0){
			if (category == 0){
				questions = questionsPoliticsEconomy;
			}
			if (category == 1){
				questions = questionsCulture;
			}
			if (category == 2){
				questions = questionsSociety;
			}
			if (category == 3){
				questions = questionsEnvironment;
			}
			if (category == 4){
				questions = questionsScience;
			}
		}
		else if(playMode == 1){ // deathmatch
			questions = questionsAll;
		}
		else {
			questions = questionsTutorial;
			// add Tutorial
		}
        print(questions.Count);
    }
	
	public void displayNextQuestion(){
		sourcesButton.SetActive(false);
		setButtonColorBack();
        incorrentColorShown = false;
        // don't continue during tutorial
		if(playMode == 1 && stopDeathmatch == true){
			gameOver();
		}
        if (playMode != 2){
		
			// if the answer is shown, on click show next question
			if(correct.activeInHierarchy==true||incorrect.activeInHierarchy==true||firstQuestion == true){
				firstQuestion = false;
				question = getQuestion();
				questionText.GetComponent<Text>().text = question[0];
				lowerleftText.GetComponent<Text>().text = question[3]; 
				lowerrightText.GetComponent<Text>().text = question[4]; 
				upperleftText.GetComponent<Text>().text = question[1]; 
				upperrightText.GetComponent<Text>().text = question[2]; 
				//setCorrectAnswer(question[5]);
				correctAnswer = question[5];

				// when new question is setup, remove answer
				correct.gameObject.SetActive(false);
				incorrect.gameObject.SetActive(false);
			}
		}
		if(playMode == 0){
			print("used questions count in displayNext Question: " + usedQuestions.Count);
			progressText.GetComponent<Text>().text = (usedQuestions.Count + " / 20");
		}
	}


	// nach questionsIndex 25 soll 26 kommen bei society
    public List<string> getQuestion(){
		print(questionsIndex);
		if(playMode == 0 && category == 2 && questionsIndex == 25){
			print("caaaaaaaareeeeeeeeeful, next question should be the second casino one!");
			questionsIndex = 26;
		}
		else{
			// while solange bis ein questionIndex nicht in usedQuestions ist
			do
			{
			    questionsIndex = Random.Range(0, questions.Count);
			    if (usedQuestions.Count == 20)
			   {
					gameOver();
			       print("breaked");
			       break;
			   }
			} while (questionsIndex == 26 || usedQuestions.Contains(questionsIndex));
		}
        usedQuestions.Add(questionsIndex);
        return questions[questionsIndex];
	}


	public void setCorrectAnswer(string answer){
		correctAnswer = answer;
	}


	void updateScore(){
		print("correct answer");
		score = score + 10;
		scoreText.text = " Score: " + score + " ";
		numCorrectAnswers++;

		print(category);
		// if categorymode, safe that this answer was answered correctly
		if(playMode == 0){
			if(correctlyAnswered[category].Contains(questionsIndex) == false){
				correctlyAnswered[category].Add(questionsIndex);
			}
		}
	}
    
	bool stopDeathmatch = false;
    public void clickedUpperLeft(){
		if(playMode != 2){
            activateSourceButton();
			showCorrectness();
			// wenn bereits antwort gezeigt wurde, auf nochmaliges klicken kommen sie zum lexicon eintrag
			if(correct.activeInHierarchy == true || incorrect.activeInHierarchy == true){
				entryHandler.showEntry(questions[questionsIndex][6], true);
				backFromLexicon = true;
			}
			if (correctAnswer=="1" && incorrect.activeInHierarchy == false){
				correct.gameObject.SetActive(true);
				updateScore();
			}
			else{
				if (correct.activeInHierarchy == false)
				{
					incorrect.gameObject.SetActive(true);
					stopDeathmatch = true;
                    if (incorrentColorShown == true)
                    {
                    }
                    else
                    {
                        upperleftButton.image.color = incorrectColor;
                        incorrentColorShown = true;
                    }
				}
			}
		}
	}

	private void activateSourceButton(){
        print("activateSourceButton called");
        if (questions[questionsIndex][10] == "")
        {
            print("yay, jetzt sollte sourcebutton nicht aktiviert werden");
        }
        else
        {
            sourcesButton.SetActive(true);
        }
	}

	public void showSources(){
	print("showsources called");
		// wenn bereits antwort gezeigt wurde, auf Sources klicken, dann wird das Fenster gezeigt
		if(correct.activeInHierarchy == true || incorrect.activeInHierarchy == true){
			sourcesCanvas.gameObject.SetActive(true);
			//print(question[11]);
			sourcesText.text = question[11];
			backFromLexicon = true;
			quizUI.SetActive(false);
		}
	}

	public void hideSources(){
	print("hidesources called");
		sourcesCanvas.gameObject.SetActive(false);
		quizUI.SetActive(true);
	}

	public void clickedUpperRight(){
		
		if(playMode != 2){
			activateSourceButton();
			showCorrectness();
			// wenn bereits antwort gezeigt wurde, auf nochmaliges klicken kommen sie zum lexicon eintrag
			if(correct.activeInHierarchy == true || incorrect.activeInHierarchy == true){
				entryHandler.showEntry(questions[questionsIndex][7], true);
				backFromLexicon = true;
			}
			if (correctAnswer== "2" && incorrect.activeInHierarchy == false)
			{
				correct.gameObject.SetActive(true);
				updateScore();
			}
			else{
				if (correct.activeInHierarchy == false)
				{
					incorrect.gameObject.SetActive(true);
					stopDeathmatch = true;
                    if (incorrentColorShown == true)
                    {
                    }
                    else
                    {
                        upperrightButton.image.color = incorrectColor;
                        incorrentColorShown = true;
                    }
				}
			}
			
		}
	}
		
	public void clickedLowerLeft(){
		if(playMode != 2){
		    activateSourceButton();
			showCorrectness();
			// wenn bereits antwort gezeigt wurde, auf nochmaliges klicken kommen sie zum lexicon eintrag
			if(correct.activeInHierarchy == true || incorrect.activeInHierarchy == true){
				entryHandler.showEntry(questions[questionsIndex][8], true);
				backFromLexicon = true;
			}
			if (correctAnswer== "3" && incorrect.activeInHierarchy == false)
			{
				correct.gameObject.SetActive(true);
				updateScore();
			}
			else{
			    if (correct.activeInHierarchy == false)
			    {
			        incorrect.gameObject.SetActive(true);
					stopDeathmatch = true;
                    if (incorrentColorShown == true)
                    {
                    }
                    else
                    {
                        lowerleftButton.image.color = incorrectColor;
                        incorrentColorShown = true;
                    }
			    }
			}
		}
	}
	
	public void clickedLowerRight(){
		if(playMode != 2){
			activateSourceButton();
			showCorrectness();
			// wenn bereits antwort gezeigt wurde, auf nochmaliges klicken kommen sie zum lexicon eintrag
			if(correct.activeInHierarchy == true || incorrect.activeInHierarchy == true){
				entryHandler.showEntry(questions[questionsIndex][9], true);
				backFromLexicon = true;
			}
			if (correctAnswer== "4" && incorrect.activeInHierarchy == false)
			{
				correct.gameObject.SetActive(true);
				updateScore();
			}
			else{
			    if(correct.activeInHierarchy == false)
			    {
			        incorrect.gameObject.SetActive(true);
					stopDeathmatch = true;
                    if (incorrentColorShown == true)
                    {
                    }
                    else
                    {
                        lowerrightButton.image.color = incorrectColor;
                        incorrentColorShown = true;
                    }
                    //lowerrightButton.image.color = incorrectColor;
			    }
			}
		}
	}

	void setButtonColorBack(){
		lowerleftButton.image.color = defaultButtonColor;
		lowerrightButton.image.color = defaultButtonColor;
		upperleftButton.image.color = defaultButtonColor;
		upperrightButton.image.color = defaultButtonColor;
	}

	void showCorrectness(){
		if (correctAnswer=="1"){
			upperleftButton.image.color = correctColor;
		}
		else if(correctAnswer== "2"){
			upperrightButton.image.color = correctColor;
		}
		else if (correctAnswer== "3"){
			lowerleftButton.image.color = correctColor;
		}
		else if(correctAnswer== "4"){
			lowerrightButton.image.color = correctColor;
		}
	}


	public void gameOver(){
		print("gameOver called in UIQuiz");
		usedQuestions = new List<int>();
        quizUI.SetActive(false);
		firstQuestion = true;
		incorrect.gameObject.SetActive(false);
		correct.gameObject.SetActive(false);
		progressText.gameObject.SetActive(true);
		GameOverCanvas.SetActive(true);
		gameOverScript.setVariables(score, numCorrectAnswers, playMode, category);
		scoreText.text = " Score: 0 ";
		print("used questions in gameover: "+usedQuestions.Count);
	}

    public void close()
    {
		// usedQuestions neu initialisieren, damit die fragen nachher wieder verwendet werden können
		usedQuestions = new List<int>();
        quizUI.SetActive(false);
        mainMenueCanvas.SetActive(true);
		firstQuestion = true;
		incorrect.gameObject.SetActive(false);
		correct.gameObject.SetActive(false);
		progressText.gameObject.SetActive(true);
		scoreText.text = " Score: 0 ";
    }
}
