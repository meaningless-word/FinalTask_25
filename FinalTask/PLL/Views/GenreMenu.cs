using FinalTask.BLL.Services;
using FinalTask.PLL.Helpers;
using System;
using System.Collections.Generic;

namespace FinalTask.PLL.Views
{
	public class GenreMenu
	{
		public List<string> menuItems;
		public GenreMenu()
		{
			menuItems = new List<string>()
			{
				"добавить"
			};
		}

		public void Choose()
		{
			while (true)
			{
				Console.WriteLine(@"Справочники\Жанры");
				DisplayMenu.Show(menuItems);
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							break;
						}
				}
			}
		}
	}
}
