using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(GridLayoutGroup))]
[RequireComponent(typeof(RectTransform))]
public class BoardLayoutManager : MonoBehaviour
{
	[SerializeField]	GameObject digitPrefab;
	RectTransform parentTransform;
	GridLayoutGroup parentGrid;
	float min_old = 0;
	List<GameObject> digits;

	void Awake()
	{
		parentTransform  = GetComponent<RectTransform>();
		parentGrid = GetComponent<GridLayoutGroup>();

		//test
		digits = new List<GameObject>();

	}

	void Start()
	{
		StartCoroutine(Init());
	}

	void Update()
	{
		//for test
		StartCoroutine(Init());
	}

	IEnumerator Init()
	{
		yield return new WaitForEndOfFrame();

		//compute cell sizes
		var minimum_space = Mathf.Min(
			parentTransform.rect.width - parentGrid.padding.left - parentGrid.padding.right - 8 * parentGrid.spacing.x,
			parentTransform.rect.height - parentGrid.padding.top - parentGrid.padding.bottom - 8 * parentGrid.spacing.y);
		

		//for test !
		if (min_old == minimum_space) yield break;
		foreach(var d in digits)
		{
			Destroy(d);
		}
		digits.Clear();
		//end for test


		min_old = minimum_space;
		parentGrid.cellSize = new Vector2(minimum_space / 9, minimum_space / 9);

		//generate digits
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				GameObject new_digit = Instantiate(digitPrefab) as GameObject;
				new_digit.transform.SetParent(parentTransform);

				digits.Add(new_digit);
			}
		}
	}
}
