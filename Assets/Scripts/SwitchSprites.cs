using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwitchSprites : MonoBehaviour {

	public Sprite pauseSpr;
	public Sprite clockSpr;

	private GameObject pauseBtn;
	private bool inGame;

	void Start () {
		inGame = true;
		pauseBtn = this.gameObject;
	}

	public void SwitchImages () {
		if (inGame) {
			inGame = false;
			pauseBtn.GetComponent<Image>().sprite = pauseSpr;
		}
		else if (!inGame) {
			inGame = true;
			pauseBtn.GetComponent<Image>().sprite = clockSpr;
		}
	}
}
