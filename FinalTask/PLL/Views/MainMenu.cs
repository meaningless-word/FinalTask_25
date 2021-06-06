using FinalTask.PLL.Helpers;
using System;
using System.Collections.Generic;

namespace FinalTask.PLL.Views
{
	public class MainMenu
	{
		List<string> menuItems { get; }

		public MainMenu()
		{
			menuItems = new List<string>()
			{
				"Справочники",
				"Выписки"
			};
		}

		public void Choose()
		{
			while (true)
			{
				Console.WriteLine(@"Добро пожаловать в электронную библиотеку");
				DisplayMenu.Show(menuItems);
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							Program.catalogMenu.Choose();
							break;
						}
					case "2":
						{
							Program.orderMenu.Choose();
							break;
						}
				}
			}
		}
	}
}
