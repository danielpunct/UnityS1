using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;


namespace SpeedSudokuProject
{
	public class SudokuGameRoot : ContextView
	{
		void Awake()
		{
			context = new SudokuRootContext(this);
		}
	}
}