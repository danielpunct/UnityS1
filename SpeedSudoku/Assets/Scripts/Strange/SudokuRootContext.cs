using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

namespace SpeedSudokuProject
{
	public class SudokuRootContext : MVCSContext
	{
		public SudokuRootContext(MonoBehaviour View) : base(View) { }

		protected override void mapBindings()
		{
			mediationBinder.Bind<MainView>().To<MainViewMediator>();
		}
	}
}