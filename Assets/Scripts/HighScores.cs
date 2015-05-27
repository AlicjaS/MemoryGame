using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScores : MonoBehaviour {

	public Text scoreNames;
	public Text scoreValues;

	private int[] scores;
	private string[] names = {"high34", "high45", "high46", "high56"};

	void Start () {
		scores = new int[4];
		int i = 0;
		scoreNames.text = "";
		scoreNames.text += "SIZE" + "\n";
		scoreNames.text += "---------" + "\n";
		scoreValues.text = "";
		scoreValues.text += "SCORE" + "\n";
		scoreValues.text += "---------" + "\n";
		foreach (string item in names) {
			if(PlayerPrefs.HasKey(item))
			{
				scores[i] = PlayerPrefs.GetInt(item);
			}
			else
			{
				scores[i] = 0;
				PlayerPrefs.SetInt(item, 0);
				PlayerPrefs.Save();
			}
			scoreNames.text += item.Substring(4,1) + " X " + item.Substring(5,1) + "\n";
			scoreValues.text += scores[i].ToString() + "\n";
			i++;
		}
	}
}
