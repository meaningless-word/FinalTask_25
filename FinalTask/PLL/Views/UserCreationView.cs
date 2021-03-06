using FinalTask.BLL.Models;
using FinalTask.BLL.Services;
using FinalTask.PLL.Helpers;
using System;

namespace FinalTask.PLL.Views
{
	/// <summary>
	/// класс запроса входящих параметров и визуализации создания сущности "пользователь"
	/// </summary>
	public class UserCreationView
	{
		public void Show()
		{
			try
			{
				UserDTO user = new UserDTO();

				Console.WriteLine("Введите");
				Console.Write("имя пользователя: ");
				user.Name = Console.ReadLine();
				Console.Write("e-mail: ");
				user.Email = Console.ReadLine();

				using (LibraryService libraryService = new LibraryService())
				{
					var r = libraryService.Create(user);
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
