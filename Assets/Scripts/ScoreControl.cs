using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreControl : MonoBehaviour, ISizeCtrl {
	
	public int hValue { get; set; }
	public int wValue { get; set; }

	public Text scoreTxt;
	public Text highTxt;
	public GameObject gameoverPanel;
		
	private int score = 0;
	private int highScore;
	private string curGame;
	private bool gameover;
	private bool paused;
	private float timePaused;
	private GameControl gmControl;

	void Start() {
		gmControl = this.GetGM ();
		score = 600;
		scoreTxt.text = score.ToString ();
		gameover = false;
		paused = false;
		timePaused = 0;
	}

	void Update(){
		if (!gameover && !paused) {
			score = Mathf.CeilToInt (600 - Time.timeSinceLevelLoad + timePaused);
			scoreTxt.text = score.ToString ();
			if (score == 0) {
				GameOver();
			}
		}
	}

	public void SetSize(int h, int w, bool show){
		hValue = h;
		wValue = w;
		curGame = "high" + hValue.ToString () + wValue.ToString ();
		InitHighScore (curGame);
	}

	private void InitHighScore(string highName){
		if(PlayerPrefs.HasKey(highName))
		{
			highScore = PlayerPrefs.GetInt(highName);
		}
		else
		{
			highScore = 0;
			PlayerPrefs.SetInt(highName, highScore);
			PlayerPrefs.Save();
		}
		highTxt.text = highScore.ToString ();
	}

	private void CheckScore(){
		if(score > highScore){
			highScore = score;
			highTxt.text = highScore.ToString();
			PlayerPrefs.SetInt(curGame, highScore);
			PlayerPrefs.Save();
		}
	}

	public void GameOver(){
		gameover = true;
		gameoverPanel.SetActive (true);
		Text gmTxt = gameoverPanel.GetComponentInChildren<Text> ();
		if (score > 0) {
			gmTxt.text = "YOUR SCORE:" + "\n" + score.ToString ();
			CheckScore ();
		} else {
			gmTxt.text = "GAME OVER" + "\n" + "TRY AGAIN";
		}
	}

	public void GamePause(){
		if (!paused) {
			paused = true;
			timePaused -= Time.timeSinceLevelLoad;
			gmControl.DeactiveBtns();
		}
		else if (paused) {
			paused = false;
			timePaused += Time.timeSinceLevelLoad;
			gmControl.ActiveBtns();
		}
	}
}





