using UnityEngine;
using System.Collections;

public class GameOptions : MonoBehaviour {
	
	void Start () {
		//xx
	}
	
	public void MenuLoad(){
		Application.LoadLevel (1);
	}

	public void GameLoad(){
		Application.LoadLevel (2);
	}

	public void HelpLoad(){
		Application.LoadLevel (3);
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void HighScoresLoad(){
		Application.LoadLevel (4);
	}
}
