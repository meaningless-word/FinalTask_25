using FinalTask.BLL.Models;
using FinalTask.BLL.Services;
using FinalTask.PLL.Helpers;
using System;

namespace FinalTask.PLL.Views
{
	/// <summary>
	/// класс запроса входящих параметров и визуализации создания сущности "жанр"
	/// </summary>
	public class GenreCreationView
	{
		public void Show()
		{
			try
			{
				GenreDTO genre = new GenreDTO();

				Console.WriteLine("Введите");
				Console.Write("название жанра: ");
				genre.Name = Console.ReadLine();
				
				using (LibraryService libraryService = new LibraryService())
				{
					var r = libraryService.Create(genre);
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