using FinalTask.BLL.Exceptions;
using FinalTask.BLL.Models;
using FinalTask.BLL.Services;
using FinalTask.PLL.Helpers;
using System;

namespace FinalTask.PLL.Views
{
	/// <summary>
	/// класс запроса входящих параметров и визуализации выдачи книги пользователю
	/// </summary>
	public class UserGiveBookView
	{
		public void Show()
		{
			try
			{
				UserDTO user = new UserDTO();

				Console.Write("введите Id пользователя: ");
				user.Id = int.Parse(Console.ReadLine());
				Console.Write("введите Id выдаваемой книги: ");
				user.GivedBookId = int.Parse(Console.ReadLine());
				using (LibraryService libraryService = new LibraryService())
				{
					libraryService.Update(user);
					Console.WriteLine("запись изменена");
				}
			}
			catch (FormatException)
			{
				AlertMessage.Show("Введено некорректное числовое значение");
			}
			catch (BookNotFoundException)
			{
				AlertMessage.Show("Указанная книга не найдена");
			}
			catch (UserNotFoundException)
			{
				AlertMessage.Show("Указанный пользователь не найден");
			}
			catch (Exception ex)
			{
				AlertMessage.Show(ex.Message);
			}
		}
	}
}
