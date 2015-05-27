using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GridBuilder : MonoBehaviour {

	public GameObject prefCard;
	public Sprite[] frontPics;
	
	private List<Sprite> curSprites;
	private float gridHeight = 400f;
	private float gridWidth = 500f;
	
	void Start () {
		//xx
	}

	public void BuildGrid(int hVal, int wVal)
	{
		curSprites = new List<Sprite> ();
		SpritesListCreator (hVal, wVal);
		GameObject instBtn;
		int cardIndex;
		RectTransform[] instBtnRect = new RectTransform[2];
		GameObject btnPar = GameObject.FindGameObjectWithTag ("cards");
		float cardSize = Mathf.Min (gridWidth / wVal,
		                            gridHeight / hVal);
		for (int i=0; i<wVal; i++) {
			for(int j=0;j<hVal;j++){
				instBtn = Instantiate(prefCard, new Vector3(0f, 0f, 0f), Quaternion.identity)as GameObject;
				instBtn.transform.SetParent(btnPar.transform);
				instBtn.name = "card" + i.ToString() + j.ToString();
				instBtnRect = instBtn.GetComponentsInChildren<RectTransform> ();
				instBtnRect[0].localPosition = new Vector3((i+0.5f)*cardSize-cardSize*wVal/2f,
				                                           (j+0.5f)*cardSize-cardSize*hVal/2f,
				                                           0f);
				foreach(RectTransform nRect in instBtnRect)
				{
					nRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, cardSize);
					nRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, cardSize);
					nRect.localScale = new Vector3(1f, 1f, 1f);
				}
				cardIndex = Random.Range(0, curSprites.Count);
				instBtn.GetComponent<Image>().sprite = curSprites[cardIndex];
				curSprites.RemoveAt(cardIndex);
				curSprites.TrimExcess();
			}
		}
	}
	
	private void SpritesListCreator(int hVal, int wVal){
		int typesQty = hVal * wVal/2;
		curSprites.Clear ();
		for (int i=0; i<typesQty; i++) {
			curSprites.Add(frontPics[i]);
			curSprites.Add(frontPics[i]);
		}
	}
}
