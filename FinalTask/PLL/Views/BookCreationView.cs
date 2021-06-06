using FinalTask.BLL.Models;
using FinalTask.PLL.Helpers;
using System;

namespace FinalTask.PLL.Views
{
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

				Program.bookService.Create(book);
			}
			catch (Exception ex)
			{
				AlertMessage.Show(ex.Message);
			}
		}
	}
}
