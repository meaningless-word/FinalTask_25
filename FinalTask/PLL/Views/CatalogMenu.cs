using FinalTask.PLL.Helpers;
using System;
using System.Collections.Generic;

namespace FinalTask.PLL.Views
{
	public class CatalogMenu
	{
		public List<string> menuItems;
		public CatalogMenu()
		{
			menuItems = new List<string>()
			{
				"Книги",
				"Пользователи",
				"Жанры",
				"Авторы"
			};
		}

		public void Choose()
		{
			while (true)
			{
				Console.WriteLine(@"Справочники");
				DisplayMenu.Show(menuItems);
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							Program.bookMenu.Choose();
							break;
						}
					case "2":
						{
							Program.userMenu.Choose();
							break;
						}
					case "3":
						{
							Program.genreMenu.Choose();
							break;
						}
					case "4":
						{
							Program.authorMenu.Choose();
							break;
						}
				}
			}
		}
	}
}
