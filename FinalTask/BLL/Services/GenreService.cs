using FinalTask.BLL.Exceptions;
using FinalTask.BLL.Models;
using FinalTask.DAL.Entities;
using FinalTask.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.BLL.Services
{
	public class GenreService
	{
		GenreRepository genreRepository;
		public GenreService()
		{
			genreRepository = new GenreRepository();
		}

		public void Create(string genre)
		{
			Genre entity = new Genre(genre);
			genreRepository.Create(entity);
		}

		/// <summary>
		/// добавление записи, если такой ещё не было, либо возврат существующей
		/// </summary>
		/// <param name="genre">наименование</param>
		/// <returns></returns>
		public Genre CreateIfNotExists(string genre)
		{
			Genre item = genreRepository.Read(genre);
			if (item is null) Create(genre);
			return genreRepository.Read(genre);
		}
	}
}
