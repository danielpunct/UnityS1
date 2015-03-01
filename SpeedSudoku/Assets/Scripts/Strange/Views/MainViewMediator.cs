using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace SpeedSudokuProject
{
	public class MainViewMediator : EventMediator
	{
		[Inject]
		public MainView _View { get; set; }

		public override void OnRegister()
		{
			_View.Init();
		}
	}
}
