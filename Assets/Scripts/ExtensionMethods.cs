using UnityEngine;
using System.Collections;

public static class ExtensionMethods{

	public static SysRoot GetRoot(this MonoBehaviour script)
	{
		GameObject root = GameObject.FindGameObjectWithTag("root");
		return root.GetComponent<SysRoot>();
	}

	public static GameControl GetGM(this MonoBehaviour script)
	{
		GameObject root = GameObject.FindGameObjectWithTag("root");
		return root.GetComponent<GameControl>();
	}
}
