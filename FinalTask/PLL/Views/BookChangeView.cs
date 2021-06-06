using FinalTask.BLL.Models;
using FinalTask.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask.PLL.Views
{
	public class BookChangeView
	{
		public void Show()
		{
			try
			{
				BookDTO book = new BookDTO();

				Console.WriteLine("замена года выпуска по Id");
				Console.Write("введите Id изменяемой книги: ");
				int id = int.Parse(Console.ReadLine());
				Console.Write("теперь год издания: ");
				book.YearOfIssue = int.Parse(Console.ReadLine());
				Program.bookService.Update(id, book);
			}
			catch (FormatException)
			{
				AlertMessage.Show("Введено некорректное числовое значение");
			}
			catch (Exception ex)
			{
				AlertMessage.Show(ex.Message);
			}
		}
	}
}
