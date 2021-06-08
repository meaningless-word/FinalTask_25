using FinalTask.PLL.Helpers;
using System;
using System.Collections.Generic;

namespace FinalTask.PLL.Views
{
	public class AuthorMenu
	{
		public List<string> menuItems;
		public AuthorMenu()
		{
			menuItems = new List<string>()
			{
				"показать все"
			};
		}

		public void Choose()
		{
			while (true)
			{
				Console.WriteLine(@"Выписки");
				DisplayMenu.Show(menuItems);
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							var doCreate = new AuthorReadAllView();
							doCreate.Show();
							break;
						}
				}
			}
		}
	}
}