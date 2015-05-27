using UnityEngine;
using System.Collections;

public interface ICardBtn
{
	int cardIndex { get; set; }
	void RegisterButton();
}

public interface ISizeCtrl
{
	int hValue { get; set; }
	int wValue { get; set; }
	void SetSize(int h, int w, bool show);
}
