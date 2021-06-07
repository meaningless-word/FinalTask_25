using FinalTask.BLL.Models;
using FinalTask.DAL.Entities;
using FinalTask.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.BLL.Services
{
	public class AuthorService
	{
		AuthorRepository authorRepository;

		public AuthorService()
		{
			authorRepository = new AuthorRepository();
		}

		public void Create(string author)
		{
			Author entity = new Author(author);
			authorRepository.Create(entity);
		}

		public List<Author> CreateIfNotExist(string authors)
		{
			string[] names = authors.Split(",");
			var result = new List<Author>();

			for (int i = 0; i < names.Length; i++)
			{
				Author item = authorRepository.Read(names[i]);
				if (item is null)
				{
					Create(names[i]);
				}

				result.Add(authorRepository.Read(names[i]));
			}
			return result;
		}
	}
}
