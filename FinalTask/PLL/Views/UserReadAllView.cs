using FinalTask.BLL.Exceptions;
using FinalTask.BLL.Models;
using FinalTask.BLL.Services;
using FinalTask.PLL.Helpers;
using System;
using System.Collections.Generic;

namespace FinalTask.PLL.Views
{
	/// <summary>
	/// класс запроса входящих параметров и визуализации запросов к сущностям "пользователь"
	/// </summary>
	public class UserReadAllView
	{
		public void Show()
		{
			using (LibraryService libraryService = new LibraryService())
			{
				List<UserDTO> users = libraryService.ReadAllUsers();
				Display(users);
			}
		}

		public void ReadedBooksByUser()
		{
			try
			{
				Console.WriteLine("количество книг у пользователя");
				Console.Write("введите Id пользователя: ");
				int id = int.Parse(Console.ReadLine());
				using (LibraryService libraryService = new LibraryService())
				{
					UserDTO user = libraryService.ReadUserById(id);
					Console.WriteLine("у пользователя книг: {0}", user.ReadedBooksCount);
				}
				
			}
			catch (FormatException)
			{
				AlertMessage.Show("Введено некорректное числовое значение");
			}
			catch (UserNotFoundException)
			{
				AlertMessage.Show("Запрашиваемый пользватель в базе не числится");
			}
			catch (Exception ex)
			{
				AlertMessage.Show(ex.Message);
			}
		}

		public void IsUserHaveBook()
		{
			try
			{
				Console.WriteLine("информация о наличии определенной книги на руках у пользователя");
				Console.Write("введите Id пользователя: ");
				int userId = int.Parse(Console.ReadLine());
				Console.Write("введите Id интересуемой книги: ");
				int bookId = int.Parse(Console.ReadLine());
				using (LibraryService libraryService = new LibraryService())
				{
					Console.WriteLine(libraryService.IsUserHaveBook(userId, bookId) ? "есть" : "нет");
				}
				
			}
			catch (FormatException)
			{
				AlertMessage.Show("Введено некорректное числовое значение");
			}
			catch (UserNotFoundException)
			{
				AlertMessage.Show("Запрашиваемый пользватель в базе не числится");
			}
			catch (BookNotFoundException)
			{
				AlertMessage.Show("Указанная книга в базе не числится");
			}
			catch (Exception ex)
			{
				AlertMessage.Show(ex.Message);
			}
		}

		private void Display(List<UserDTO> users)
		{
			Console.WriteLine("{0,-30}:{1,-20}:{2,9}:{3,6}", "имя пользователя", "e-mail", "прочитано", "Id");
			users.ForEach(x =>
			{
				Console.WriteLine("{0,-30}:{1,-20}:{2,9}:{3,6}", x.Name, x.Email, x.ReadedBooksCount, x.Id);
			});
		}
	}
}
