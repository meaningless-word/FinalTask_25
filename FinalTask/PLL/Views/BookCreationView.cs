using FinalTask.BLL.Models;
using FinalTask.BLL.Services;
using FinalTask.PLL.Helpers;
using System;

namespace FinalTask.PLL.Views
{
	/// <summary>
	/// класс запроса входящих параметров и визуализации создания сущности "книга"
	/// </summary>
	public class BookCreationView
	{
		public void Show()
		{
			try
			{
				BookDTO book = new BookDTO();

				Console.WriteLine("Введите");
				Console.Write("название книги: ");
				book.Title = Console.ReadLine();
				Console.Write("год издания: ");
				book.YearOfIssue = int.Parse(Console.ReadLine());
				Console.Write("имя автора (если несколько, то через запятую): ");
				book.Authors = Console.ReadLine();
				Console.Write("жанр: ");
				book.Genre = Console.ReadLine();

				using (LibraryService libraryService = new LibraryService())
				{
					var r = libraryService.Create(book);
					Console.WriteLine("добавлена запись с Id = {0}", r.Id);
				}
			}
			catch (Exception ex)
			{
				AlertMessage.Show(ex.Message);
			}
		}
	}
}
