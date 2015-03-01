using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class AnimatedAutoText : MonoBehaviour
{
	[SerializeField]	GameObject textPrefab;
	[SerializeField]	string text;
	[SerializeField]	float tokenDelay;
	[SerializeField]	bool debugStart;
	[SerializeField]	Canvas parentCanvas;


	void Awake()
	{
		accumulatedWidht = Vector3.zero;
		instantiatedTexts = new List<Text>();
	}

	void Update()
	{
		if (!debugStart)
			return;

		StartCoroutine(ShowSplits());
		debugStart = false;
	}

	IEnumerator ShowSplits()
	{
		foreach (var t in instantiatedTexts)
		{
			Destroy(t.gameObject);
		}
		instantiatedTexts.Clear();
		accumulatedWidht = Vector3.zero;
		foreach (var word in GetSplitsByWords(text))
		{
			Text new_token = ( Instantiate(textPrefab,  accumulatedWidht, Quaternion.identity) as GameObject).GetComponent(typeof(Text)) as Text;
			new_token.transform.SetParent(transform, false);
			
			new_token.text = word;
			instantiatedTexts.Add(new_token);
			accumulatedWidht.x += new_token.text.Length * 10;

			yield return new WaitForSeconds(tokenDelay);
		}
	}


	string[] GetSplitsByWords(string Text)
	{
		return Text.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
	}

	Vector3 accumulatedWidht;
	List<Text> instantiatedTexts;
}
