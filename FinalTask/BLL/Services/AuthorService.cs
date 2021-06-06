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

		public void Create(AuthorDTO author)
		{
			Author entity = new Author();

			entity.Name = author.Name;

			authorRepository.Create(entity);
		}

		public List<Author> CreateIfNotExist(AuthorDTO author)
		{
			string[] names = author.Name.Split(",");
			var result = new List<Author>();

			for (int i = 0; i < names.Length; i++)
			{
				Author item = authorRepository.ReadAll().Where(x => x.Name == names[i]).FirstOrDefault();
				if (item is null)
				{
					var a = new AuthorDTO() { Name = names[i] };
					Create(a);
				}

				result.Add(authorRepository.ReadAll().Where(x => x.Name == names[i]).FirstOrDefault());
			}

			return result;
		}


	}
}
