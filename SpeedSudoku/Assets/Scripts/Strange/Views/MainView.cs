﻿using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

namespace SpeedSudokuProject
{
	public class MainView : View
	{
		[SerializeField]	Text titleText;
		[SerializeField]	BoardLayoutManager board;		

		public void Init()
		{
			titleText.text = "Lives: 4";

			//gameBoard.
		}
	}
}