using FinalTask.BLL.Models;
using FinalTask.PLL.Helpers;
using System;

namespace FinalTask.PLL.Views
{
	public class UserChangeView
	{
		public void Show()
		{
			try
			{
				UserDTO user = new UserDTO();

				Console.WriteLine("замена имени пользователя по Id");
				Console.Write("введите Id пользователя: ");
				int id = int.Parse(Console.ReadLine());
				Console.Write("теперь новое имя: ");
				user.Name = Console.ReadLine();
				Program.userService.Update(id, user);
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
