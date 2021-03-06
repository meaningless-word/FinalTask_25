using FinalTask.BLL.Exceptions;
using FinalTask.BLL.Models;
using FinalTask.BLL.Services;
using FinalTask.PLL.Helpers;
using System;

namespace FinalTask.PLL.Views
{
	/// <summary>
	/// класс запроса входящих параметров и визуализации изменения года издания сущности "книга"
	/// </summary>
	public class BookChangeView
	{
		public void Show()
		{
			try
			{
				BookDTO book = new BookDTO();

				Console.WriteLine("замена года выпуска по Id");
				Console.Write("введите Id изменяемой книги: ");
				book.Id = int.Parse(Console.ReadLine());
				Console.Write("теперь год издания: ");
				book.YearOfIssue = int.Parse(Console.ReadLine());

				using (LibraryService libraryService = new LibraryService())
				{
					libraryService.Update(book);
					Console.WriteLine("запись изменена");
				}
			}
			catch (FormatException)
			{
				AlertMessage.Show("Введено некорректное числовое значение");
			}
			catch (BookNotFoundException)
			{
				AlertMessage.Show("Указанная запись не найдена");
			}
			catch (Exception ex)
			{
				AlertMessage.Show(ex.Message);
			}
		}
	}
}
