using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour, ISizeCtrl {

	public int hValue { get; set; }
	public int wValue { get; set; }

	public bool showCards;
	public bool firstClicked;

	public CardBtn[] cardsMarked;

	private ScoreControl scControl;
	private GridBuilder builder;
	private bool gridBuilt;

	private List<Button> cardBtns = new List<Button> ();
	private int cardsNum;

	void Awake(){
		builder = GetComponent<GridBuilder> ();
		cardsMarked = new CardBtn[2];
	}

	void OnEnable(){
		builder.enabled = true;
		cardBtns.Clear ();
		firstClicked = false;
		gridBuilt = false;
		scControl = GameObject.FindWithTag("options").GetComponent<ScoreControl>();
	}

	void Start (){
		//xx
	}

	void Update(){
		if (!gridBuilt) {
			builder.BuildGrid (hValue, wValue);
			gridBuilt = true;
			cardsNum = hValue * wValue;
		}
		if (cardsNum == 0) {
			Debug.Log("win");
			scControl.GameOver();
		}
	}

	void OnDisable(){
		builder.enabled = false;
	}

	public void SecondClick(){
		DeactiveBtns ();
		if (cardsMarked [0].cardInd == cardsMarked [1].cardInd) {
			foreach (CardBtn cBtn in cardsMarked) {
				cardBtns.Remove (cBtn.btnObj);
				Destroy (cBtn.btnObj.gameObject);
			}
			cardBtns.TrimExcess ();
			cardsNum -= 2;
			ActiveBtns ();
		} else {
			foreach (CardBtn cBtn in cardsMarked) {
				cBtn.btnObj.GetComponent<ButtonAction>().SetVisible();
			}
		}
		firstClicked = false;
	}

	public void DeactiveBtns(){
		foreach (Button btn in cardBtns) {
			btn.interactable = false;
		}
	}

	public void ActiveBtns(){
		foreach (Button btn in cardBtns) {
			btn.interactable = true;
		}
	}

	public void AddButton(Button btn){
		cardBtns.Add (btn);
	}

	public void SetSize(int h, int w, bool show){
		hValue = h;
		wValue = w;
		showCards = show;
	}
}

public class CardBtn
{
	public int cardInd { get; set; }
	public Button btnObj { get; set; }

	public CardBtn(int nInd, Button nBtn){
		cardInd = nInd;
		btnObj = nBtn;
	}
}












