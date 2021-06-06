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

		public void Create(GenreDTO genre)
		{
			Genre entity = new Genre();

			entity.Name = genre.Name;

			genreRepository.Create(entity);
		}

		/// <summary>
		/// добавление записи, если такой ещё не было, либо возврат суествующей
		/// </summary>
		/// <param name="genre">наименование</param>
		/// <returns></returns>
		public Genre CreateIfNotExists(GenreDTO genre)
		{
			Genre item = genreRepository.ReadAll().Where(x => x.Name == genre.Name).FirstOrDefault();
			if (item is null) Create(genre);
			return genreRepository.ReadAll().Where(x => x.Name == genre.Name).FirstOrDefault();
		}
	}
}
