using UnityEngine;
using System.Collections;

public class SysRoot : MonoBehaviour {

	public static SysRoot root = null;

	private int hValRoot;
	private int wValRoot;
	private bool showCards;
	private GameControl gmControl;
	private ScoreControl scControl;

	void Awake()
	{
		if (root == null)
			root = this;
		else if (root != this)
			Destroy (gameObject);	
		DontDestroyOnLoad (gameObject);

		gmControl = GetComponent<GameControl>();
	}

	void Start () {
		hValRoot = 3;
		wValRoot = 4;
		showCards = false;
	}

	void Update () {
		//xx
	}

	void OnLevelWasLoaded(int lvl){
		gmControl.enabled = false;
		if (lvl == 2) {
			gmControl.enabled = true;
			gmControl.SetSize(hValRoot, wValRoot, showCards);
			scControl = GameObject.FindWithTag("options").GetComponent<ScoreControl>();
			scControl.SetSize(hValRoot, wValRoot, showCards);
		}
	}

	public void SetSize(int h, int w, bool show){
		hValRoot = h;
		wValRoot = w;
		showCards = show;
	}
}
