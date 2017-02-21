using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechManager : MonoBehaviour {

	/**
	 * 
	 * Not sure the fastest way to do this but since strings return as the back end delivers them,
	 * and they aren't always right, we want to simply run a circular iteration on the entire list of spoken words
	 * against the entire list of words that the each scene is listening for during each frame.  
	 * */
	private LinkedList<string> spokenWords;
	private LinkedList<string> listenWords;

	// List of listen words grouped into pharess or possible commands, per scene or dialogue menu event.
	private List<SpeechValueObject> commands;

	// Use this for initialization
	void Start () {
		commands = new List<SpeechValueObject> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		//checkforMatches ();
	}

	private void addListenWord(string word) {
		listenWords.AddLast (word);
	}

	public void addCommand(SpeechValueObject command) {
		commands.Add (command);
		//First element is string of words or word to listen for
		string[] newWords = command.listenWords;
		foreach(string word in newWords){
			listenWords.AddLast (word);
		}

	}

	public void addSpokenWord(string word) {
		spokenWords.AddLast (word);
	}

	// Up for refactor, depnding on data structure final choice
	private void checkForMatches(){
		foreach (string lWord in listenWords)
		{
			foreach (string sWord in spokenWords){
				if (lWord == sWord) {
					matchFound (sWord);
					listenWords.Remove (lWord);
					spokenWords.Remove (sWord);
				}
			}
		}
	}

	private void matchFound(string word) {
		
	}


}
