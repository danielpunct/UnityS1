using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class AutoText : MonoBehaviour
{
	[SerializeField]	Text textUI;
	[SerializeField]	string text;
	[SerializeField]	float tokenDelay;
	[SerializeField]	bool debugStart;


	string[] GetSplitsByWords(string Text)
	{
		return Text.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
	}

	void Update()
	{
		if (!debugStart)
			return;

		StartCoroutine(Split());
		debugStart = false;
	}

	IEnumerator Split()
	{
		textUI.text = "";
		foreach (var word in GetSplitsByWords(text))
		{
			textUI.text += word + " ";
			yield return new WaitForSeconds(tokenDelay);
		}
	}
}
