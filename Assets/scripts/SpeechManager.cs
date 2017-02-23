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
	private List<string> spokenWords;
	private List<string> listenWords;

	//TODO add timer to clear spokenwords after a few seconds. 

	// List of listen words grouped into pharess or possible commands, per scene or dialogue menu event.
	private List<ArrayList> commands;

	// Use this for initialization
	void Start () {
		commands = new List<ArrayList> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		//checkforMatches ();
	}

	private void addListenWord(string word) {
		listenWords.Add (word);
	}

	public void addCommand(ArrayList command) {
		commands.Add (command);
		//First element is string of words or word to listen for
		ArrayList newWords = command[0].split(" ");

		foreach(string word in newWords){
			listenWords.Add (word);
		}
	}

	public void addSpokenWord(string word) {
		ArrayList tempWords = word.Split (" ");
		if (tempWords.Count > 1) {
			foreach (string str in tempWords) {
				spokenWords.Add (word);
			}
		} else {
			spokenWords.Add (word);

		}
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
		foreach(ArrayList command in commands){

		}
	}


}
