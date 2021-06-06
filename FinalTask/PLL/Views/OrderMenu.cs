using FinalTask.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask.PLL.Views
{
	public class OrderMenu
	{
		public List<string> menuItems;
		public OrderMenu()
		{
			menuItems = new List<string>()
			{
				"список книг в алфавитном порядке",
				"список книг по убыванию года выпуска",
				"последняя вышедшая книга",
				"количество книг на руках у пользователя",
				"есть ли определенная книга на руках у пользователя",
				"проверка наличия книги по автору и названию",
				"количество книг определенного жанра в библиотеке",
				"количество книг определенного автора в библиотеке",
				"список книг определенного жанра, вышедших в период"
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
							var doRead = new BookReadAllView();
							doRead.AlphabeticTitleShow();
							break;
						}
					case "2":
						{
							var doRead = new BookReadAllView();
							doRead.YearIssueDescShow();
							break;
						}
					case "3":
						{
							var doRead = new BookReadAllView();
							doRead.LastIssuedShow();
							break;
						}
					case "4":
						{
							var doRead = new UserReadAllView();
							doRead.ReadedBooksByUser();
							break;
						}
					case "5":
						{
							var doRead = new UserReadAllView();
							doRead.IsUserHaveBook();
							break;
						}
					case "6":
						{
							var doRead = new BookReadAllView();
							doRead.IsTheBookINLibrary();
							break;
						}
					case "7":
						{
							var doRead = new BookReadAllView();
							doRead.CountByGenre();
							break;
						}
					case "8":
						{
							var doRead = new BookReadAllView();
							doRead.CountByAuthor();
							break;
						}
					case "9":
						{
							var doRead = new BookReadAllView();
							doRead.GenreAndPeriodShow();
							break;
						}
				}
			}
		}
	}
}
