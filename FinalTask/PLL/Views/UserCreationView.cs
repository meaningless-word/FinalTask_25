using FinalTask.BLL.Exceptions;
using FinalTask.BLL.Models;
using FinalTask.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask.PLL.Views
{
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

				Program.userService.Create(user);
			}
			catch (Exception ex)
			{
				AlertMessage.Show(ex.Message);
			}
		}
	}
}
