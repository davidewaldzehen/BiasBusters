using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LexiconEntryHandler : MonoBehaviour {

	public List<GameObject> entries;
	public GameObject lexiconCanvas;
	public GameObject quizUI;
	public bool calledFrom; // 0: lexicon, 1: from ingame
	int index; // to save which entry is shown


	// Use this for initialization
	void Start () {

		 entries = new List<GameObject>();
         foreach (Transform child in transform)
         {
             if (child != transform)
             {
                 entries.Add(child.gameObject);
				 child.gameObject.GetComponent<Canvas>().sortingOrder = 1;
             }
         }
	}
	

	int findEntryIndex(string entryName){
		for(int i = 0; i < entries.Count; i++){
			if(entryName == entries[i].name){
				return i;
			}
		}
		print("Apparently the entryName was not found in the Lexicon!");
		return -1;
	}


	public void showEntry(string entryName, bool fromWhereCalled){
		calledFrom = fromWhereCalled;

		// aktuellen canvas aus machen
		if(fromWhereCalled == false){
			lexiconCanvas.SetActive(false);
		}
		else{
			quizUI.SetActive(false);
		}

		// eintrag zeigen
		index = findEntryIndex(entryName);
		entries[index].SetActive(true);
	}


	public void back(){
		// disable shown entry
		entries[index].SetActive(false);

		// enable canvas from which the entry was called (lexicon or quiz)
		if(calledFrom == false){
			lexiconCanvas.SetActive(true);
		}
		else{
			quizUI.SetActive(true);
		}
	}
}
