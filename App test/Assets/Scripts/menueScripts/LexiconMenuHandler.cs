using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LexiconMenuHandler : MonoBehaviour {

    public GameObject mainMenuCanvas;
    public GameObject lexiconCanvas;
	public GameObject lexiconEntries;
	LexiconEntryHandler entryHandler;

	void Start () {
		entryHandler = lexiconEntries.GetComponent<LexiconEntryHandler>();
	}
	
	

	public void back () {
        lexiconCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    }

	public void framingEffect(){
		entryHandler.showEntry("Framing Effect", false);
	}

	public void humorEffect(){
		entryHandler.showEntry("Humor Effect", false);
	}
	
	public void anchoring(){
		entryHandler.showEntry("Anchoring", false);
	}

	public void authorityBias(){
		entryHandler.showEntry("Authority Bias", false);
	}
	
	public void availabilityCascade(){
		entryHandler.showEntry("Availability Cascade", false);
	}
	
	public void availabilityHeuristic(){
		entryHandler.showEntry("Availability Heuristic", false);
	}

	public void baseRateFallacy(){
		entryHandler.showEntry("Base Rate Fallacy", false);
	}

	public void beliefBias(){
		entryHandler.showEntry("Belief Bias", false);
	}

	public void conjunctionFallacy(){
		entryHandler.showEntry("Conjunction Fallacy", false);
	}

	public void contrastEffect(){
		entryHandler.showEntry("Contrast Effect", false);
	}

	public void declinism(){
		entryHandler.showEntry("Declinism", false);
	}

	public void gamblersFallacy(){
		entryHandler.showEntry("Gamblers Fallacy", false);
	}

	public void identifiableVictimEffect(){
		entryHandler.showEntry("Identifiable Victim Effect", false);
	}
	
	public void illusionOfValidity(){
		entryHandler.showEntry("Illusion of Validity", false);
	}

	public void outcomeBias(){
		entryHandler.showEntry("Outcome Bias", false);
	}

	public void rhymeAsReasonEffect(){
		entryHandler.showEntry("Rhyme as Reason Effect", false);
	}

	public void groupAttributionError(){
		entryHandler.showEntry("Group Attribution Error", false);
	}

	public void haloEffect(){
		entryHandler.showEntry("Halo Effect", false);
	}

	public void ingroupBias(){
		entryHandler.showEntry("Ingroup Bias", false);
	}

	public void justWorldHypothesis(){
		entryHandler.showEntry("Just-World Hypothesis", false);
	}

	public void naiveRealism(){
		entryHandler.showEntry("Naive Realism", false);
	}

	public void systemJustification(){
		entryHandler.showEntry("System Justification", false);
	}

	public void bizarrenessEffect(){
		entryHandler.showEntry("Bizarreness Effect", false);
	}

	public void forerEffect(){
		entryHandler.showEntry("Forer Effect", false);
	}

	public void illusoryTruthEffect(){
		entryHandler.showEntry("Illusory Truth Effect", false);
	}

	public void confirmationBias(){
		entryHandler.showEntry("Confirmation Bias", false);
	}
}
