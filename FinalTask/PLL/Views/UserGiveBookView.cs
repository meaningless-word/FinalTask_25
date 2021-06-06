using FinalTask.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask.PLL.Views
{
	public class UserGiveBookView
	{
		public void Show()
		{
			try
			{
				Console.Write("введите Id пользователя: ");
				int userId = int.Parse(Console.ReadLine());
				Console.Write("введите Id выдаваемой книги: ");
				int bookId = int.Parse(Console.ReadLine());
				Program.userService.Update(userId, bookId);
			}
			catch (Exception ex)
			{
				AlertMessage.Show(ex.Message);
			}
		}
	}
}
