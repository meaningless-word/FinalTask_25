using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask.DAL.Repositories
{
	interface IRepository<T>
	{
		void Create(T entity);
		T Read(int id);
		List<T> ReadAll();
		void Update(int id, T entity);
		void Delete(int id);
	}
}
