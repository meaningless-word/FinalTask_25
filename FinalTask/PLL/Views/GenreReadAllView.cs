using FinalTask.BLL.Models;
using FinalTask.BLL.Services;
using System;
using System.Collections.Generic;

namespace FinalTask.PLL.Views
{
	/// <summary>
	/// класс запроса входящих параметров и визуализации запросов к сущностям "жанр"
	/// </summary>
	public class GenreReadAllView
	{
		public void Show()
		{
			using (LibraryService libraryService = new LibraryService())
			{
				List<GenreDTO> genres = libraryService.ReadAllGenres();
				Display(genres);
			}
		}

		private void Display(List<GenreDTO> genres)
		{
			Console.WriteLine("{0}:{1}", "наименование".PadRight(30, '.'), "Id".PadRight(6, '.'));
			genres.ForEach(x =>
			{
				Console.WriteLine("{0,-30}:{1,6}", x.Name, x.Id);
			});
		}
	}
}
