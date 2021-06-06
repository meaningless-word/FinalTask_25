using FinalTask.BLL.Exceptions;
using FinalTask.BLL.Models;
using FinalTask.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.PLL.Views
{
	public class BookReadAllView
	{
		public void Show()
		{
			List<BookDTO> books = Program.bookService.ReadAll();
			Display(books);
		}

		public void AlphabeticTitleShow()
		{
			List<BookDTO> books = Program.bookService.ReadAll().OrderBy(x => x.Title).ToList();
			Display(books);
		}

		public void YearIssueDescShow()
		{
			List<BookDTO> books = Program.bookService.ReadAll().OrderByDescending(x => x.YearOfIssue).ToList();
			Display(books);
		}

		public void LastIssuedShow()
		{
			List<BookDTO> books = new List<BookDTO>();
			books.Add(Program.bookService.ReadAll().OrderByDescending(x => x.YearOfIssue).FirstOrDefault());
			Display(books);
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
				Console.WriteLine(Program.bookService.IsTheBookInLibrary(title, author) ? "есть" : "нет");
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
				List<BookDTO> books = Program.bookService.ReadByGenre(genre);
				Console.WriteLine("{0} книг жанра {1} присутствуют в библиотеке", books.Count, String.Join(", ", books.Select(x => x.Genre).Distinct()));
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
				List<BookDTO> books = Program.bookService.ReadByAuthor(author);
				Console.WriteLine("{0} книг автора {1} присутствуют в библиотеке", books.Count, String.Join(", ", books.Select(x => x.Authors).Distinct()));
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
				List<BookDTO> books = Program.bookService.ReadByGenreInPeriod(genre, yearAfter, yearBefore);
				Display(books);
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
