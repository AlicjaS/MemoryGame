using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ButtonAction : MonoBehaviour, ICardBtn {

	public int cardIndex { get{return indC;} set{indC = value;} }

	private Image imgObj;
	private int indC;
	private GameControl gmControl;

	void Start(){
		gmControl = this.GetGM ();
		RegisterButton ();
		GetIndex ();
		if (gmControl.showCards)
			SetTransparent ();
	}

	private void GetIndex(){
		imgObj = this.gameObject.GetComponent<Image> ();
		Image parImg = this.gameObject.GetComponentsInParent<Image> () [1];
		string imgName = parImg.sprite.name;
		indC = int.Parse (imgName.Substring (5));
	}

	public void RegisterButton(){
		gmControl.AddButton (this.gameObject.GetComponent<Button> ());
	}

	public void Click(){
		imgObj.enabled = false;
		if (gmControl.firstClicked) {
			gmControl.cardsMarked[1] = new CardBtn(indC, this.gameObject.GetComponent<Button> ());
			gmControl.SecondClick ();
		} else {
			gmControl.firstClicked = true;
			gmControl.cardsMarked[0] = new CardBtn(indC, this.gameObject.GetComponent<Button> ());
		}
	}

	public void SetVisible(){
		StartCoroutine ("AlphaBtn");
	}

	public void SetTransparent(){
		imgObj.enabled = false;
		StartCoroutine ("AlphaBtn");
	}
	
	IEnumerator AlphaBtn()
	{
		yield return new WaitForSeconds(0.5f);
		gmControl.ActiveBtns ();
		imgObj.enabled = true;
	}
}
