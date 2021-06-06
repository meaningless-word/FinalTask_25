using FinalTask.PLL.Helpers;
using System;
using System.Collections.Generic;

namespace FinalTask.PLL.Views
{
	public class BookMenu
	{
		public List<string> menuItems;
		public BookMenu()
		{
			menuItems = new List<string>()
			{
				"добавить книгу",
				"показать все",
				"изменить год выпуска"
			};
		}

		public void Choose()
		{
			while (true)
			{
				Console.WriteLine(@"Справочники\Книги");
				DisplayMenu.Show(menuItems);
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							var doCreate = new BookCreationView();
							doCreate.Show();
							break;
						}
					case "2":
						{
							var doRead = new BookReadAllView();
							doRead.Show();
							break;
						}
					case "3":
						{
							var doUpdate = new BookChangeView();
							doUpdate.Show();
							break;
						}
				}
			}
		}
	}
}
