using FinalTask.BLL.Models;
using FinalTask.BLL.Services;
using System;
using System.Collections.Generic;

namespace FinalTask.PLL.Views
{
	/// <summary>
	/// класс визуализации результатов запросов для сущности "авторы"
	/// </summary>
	public class AuthorReadAllView
	{
		/// <summary>
		/// 
		/// </summary>
		public void Show()
		{
			using (LibraryService libraryService = new LibraryService())
			{
				List<AuthorDTO> authors = libraryService.ReadAllAuthors();
				Display(authors);
			}
		}
		/// <summary>
		/// вывод списка в табличном представлении
		/// </summary>
		/// <param name="authors"></param>
		private void Display(List<AuthorDTO> authors)
		{
			Console.WriteLine("{0}:{1}", "ФИО автора".PadRight(40, '.'), "Id".PadRight(6, '.'));
			authors.ForEach(x =>
			{
				Console.WriteLine("{0,-40}:{1,6}", x.Name, x.Id);
			});
		}
	}
}
