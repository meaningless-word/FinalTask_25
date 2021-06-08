using FinalTask.BLL.Exceptions;
using FinalTask.BLL.Models;
using FinalTask.BLL.Services;
using FinalTask.PLL.Helpers;
using System;

namespace FinalTask.PLL.Views
{
	/// <summary>
	/// класс запроса входящих параметров и визуализации изменения наименования сущности "жанр"
	/// </summary>
	public class GenreChangeView
	{
		public void Show()
		{
			try
			{
				GenreDTO genre = new GenreDTO();

				Console.WriteLine("замена наименования жанра по Id");
				Console.Write("введите Id изменяемого жанра: ");
				genre.Id = int.Parse(Console.ReadLine());
				Console.Write("теперь новое название жанра: ");
				genre.Name = Console.ReadLine();

				using (LibraryService libraryService = new LibraryService())
				{
					libraryService.Update(genre);
					Console.WriteLine("запись изменена");
				}
			}
			catch (FormatException)
			{
				AlertMessage.Show("Введено некорректное числовое значение");
			}
			catch (GenreNotFoundException)
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
