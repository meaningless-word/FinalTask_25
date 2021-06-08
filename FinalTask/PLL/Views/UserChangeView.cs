using FinalTask.BLL.Exceptions;
using FinalTask.BLL.Models;
using FinalTask.BLL.Services;
using FinalTask.PLL.Helpers;
using System;

namespace FinalTask.PLL.Views
{
	/// <summary>
	/// класс запроса входящих параметров и визуализации изменения имени сущности "пользователь"
	/// </summary>
	public class UserChangeView
	{
		public void Show()
		{
			try
			{
				UserDTO user = new UserDTO();

				Console.WriteLine("замена имени пользователя по Id");
				Console.Write("введите Id пользователя: ");
				user.Id = int.Parse(Console.ReadLine());
				Console.Write("теперь новое имя: ");
				user.Name = Console.ReadLine();
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
