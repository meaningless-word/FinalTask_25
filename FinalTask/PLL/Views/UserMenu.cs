using FinalTask.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask.PLL.Views
{
	public class UserMenu
	{
		public List<string> menuItems;
		public UserMenu()
		{
			menuItems = new List<string>()
			{
				"добавить пользователя",
				"показать все",
				"выдать книгу",
				"поменять имя"
			};
		}

		public void Choose()
		{
			while (true)
			{
				Console.WriteLine(@"Справочники\Пользователи");
				DisplayMenu.Show(menuItems);
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							var doCreate = new UserCreationView();
							doCreate.Show();
							break;
						}
					case "2":
						{
							var doRead = new UserReadAllView();
							doRead.Show();
							break;
						}
					case "3":
						{
							var doGive = new UserGiveBookView();
							doGive.Show();
							break;
						}
					case "4":
						{
							var doUpdate = new UserChangeView();
							doUpdate.Show();
							break;
						}
				}
			}
		}
	}
}
