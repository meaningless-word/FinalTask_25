using FinalTask.BLL.Models;
using FinalTask.BLL.Services;
using FinalTask.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.PLL.Views
{
	/// <summary>
	/// класс запроса входящих параметров и визуализации запросов к сущностям "книга"
	/// </summary>
	public class BookReadAllView
	{

		public void Show()
		{
			using (LibraryService libraryService = new LibraryService())
			{
				List<BookDTO> books = libraryService.ReadAllBooks();
				Display(books);
			}
		}

		public void AlphabeticTitleShow()
		{
			using (LibraryService libraryService = new LibraryService())
			{
				List<BookDTO> books = libraryService.ReadAllBooks().OrderBy(x => x.Title).ToList();
				Display(books);
			}
		}

		public void YearIssueDescShow()
		{
			using (LibraryService libraryService = new LibraryService())
			{
				List<BookDTO> books = libraryService.ReadAllBooks().OrderByDescending(x => x.YearOfIssue).ToList();
				Display(books);
			}
		}

		public void LastIssuedShow()
		{
			using (LibraryService libraryService = new LibraryService())
			{
				List<BookDTO> books = new List<BookDTO>();
				books.Add(libraryService.ReadAllBooks().OrderByDescending(x => x.YearOfIssue).FirstOrDefault());
				Display(books);
			}

		}

		public void IsTheBookINLibrary()
		{
			try
			{
				Console.WriteLine("информация о наличии определенной книги в библиотеке");
				Console.Write("введите часть имени автора: ");
				string author = Console.ReadLine();
				Console.Write("введите часть наименования книги: ");
				string title = Console.ReadLine();
				using (LibraryService libraryService = new LibraryService())
				{
					Console.WriteLine(libraryService.IsTheBookInLibrary(title, author) ? "есть" : "нет");
				}
			}
			catch (Exception ex)
			{
				AlertMessage.Show(ex.Message);
			}
		}

		public void CountByGenre()
		{
			try
			{
				Console.WriteLine("подсчёт количества книг определенного жанра в библиотеке");
				Console.Write("введите часть наименования жанра: ");
				string genre = Console.ReadLine();
				using (LibraryService libraryService = new LibraryService())
				{
					List<BookDTO> books = libraryService.ReadBooksByGenre(genre);
					Console.WriteLine("{0} книг жанра {1} присутствуют в библиотеке", books.Count, String.Join(", ", books.Select(x => x.Genre).Distinct()));
				}
			}
			catch (Exception ex)
			{
				AlertMessage.Show(ex.Message);
			}
		}

		public void CountByAuthor()
		{
			try
			{
				Console.WriteLine("подсчёт количества книг определенного автора в библиотеке");
				Console.Write("введите часть имени автора: ");
				string author = Console.ReadLine();
				using (LibraryService libraryService = new LibraryService())
				{
					List<BookDTO> books = libraryService.ReadBooksByAuthor(author);
					Console.WriteLine("{0} книг автора {1} присутствуют в библиотеке", books.Count, String.Join(", ", books.Select(x => x.Authors).Distinct()));
				}
			}
			catch (Exception ex)
			{
				AlertMessage.Show(ex.Message);
			}
		}

		public void GenreAndPeriodShow()
		{
			try
			{
				Console.WriteLine("список книг определенного жанра и вышедших между определенными годами");
				Console.Write("введите часть наименования жанра: ");
				string genre = Console.ReadLine();
				Console.Write("введите год выпуска начала периода: ");
				int yearAfter = int.Parse(Console.ReadLine());
				Console.Write("введите год выпуска окончания периода: ");
				int yearBefore = int.Parse(Console.ReadLine());
				using (LibraryService libraryService = new LibraryService())
				{
					List<BookDTO> books = libraryService.ReadBooksByGenre(genre).Where(x => x.YearOfIssue >= yearAfter && x.YearOfIssue <= yearBefore).ToList();
					Display(books);
				}
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

		private void Display(List<BookDTO> books)
		{
			Console.WriteLine("{0}:{1}:{2}:{3}:{4}", "наименование".PadRight(30, '.'), "год.", "автор(ы)".PadRight(30, '.'), "жанр".PadRight(20, '.'), "Id".PadRight(6, '.'));
			books.ForEach(x =>
			{
				Console.WriteLine("{0,-30}:{1,4}:{2,-30}:{3,-20}:{4,6}", x.Title, x.YearOfIssue, x.Authors, x.Genre, x.Id);
			});
		}
	}
}
