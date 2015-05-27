using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MenuOptions : MonoBehaviour {

	private SysRoot root;
	private bool showCards;

	public Toggle showCardsCheck;

	void Awake(){
		root = this.GetRoot ();
	}

	void Start(){
		showCards = false;
	}

	public void ShowCards(){
		showCards = showCardsCheck.isOn;
	}

	public void GameLoad(string size){
		string hStr = size.Substring (0, 1);
		string wStr = size.Substring (1, 1);
		int hInt = 0;
		int wInt = 0;
		try{
			hInt = int.Parse (hStr);
		} catch(Exception ex){
			Debug.Log(ex);
			return;
		}
		try{
			wInt = int.Parse (wStr);
		} catch(Exception ex){
			Debug.Log(ex);
			return;
		}
		root.SetSize (hInt, wInt, showCards);
		Application.LoadLevel (2);
	}
}
