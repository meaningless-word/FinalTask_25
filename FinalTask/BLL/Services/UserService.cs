using FinalTask.BLL.Exceptions;
using FinalTask.BLL.Models;
using FinalTask.DAL.Entities;
using FinalTask.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.BLL.Services
{
	public class UserService
	{
		UserRepository userRepository;
		BookRepository bookRepository;

		public UserService()
		{
			userRepository = new UserRepository();
			bookRepository = new BookRepository();
		}

		public void Create(UserDTO user)
		{
			User entity = new User();

			entity.Name = user.Name;
			entity.Email = user.Email;

			userRepository.Create(entity);
		}

		public UserDTO Read(int id)
		{
			User user = userRepository.Read(id);
			if (user is null) throw new UserNotFoundException();
			return new UserDTO(user.Id, user.Name, user.Email, user.ReadedBooks.Count);
		}

		public List<UserDTO> ReadAll()
		{
			List<User> users = userRepository.ReadAll();
			return users.Select(x => new UserDTO(x.Id, x.Name, x.Email, x.ReadedBooks.Count)).ToList();
		}

		public void Update(int userId, int bookId)
		{
			Book book = bookRepository.Read(bookId);
			User user = userRepository.Read(userId);
			user.ReadedBooks.Add(book);

			userRepository.Update(userId, user);
		}

		public void Update(int id, UserDTO user)
		{
			User entity = userRepository.Read(id);
			entity.Name = user.Name;

			userRepository.Update(id, entity);
		}

		public bool IsUserHaveBook(int userId, int bookId)
		{
			User user = userRepository.Read(userId);
			if (user is null) throw new UserNotFoundException();
			Book book = bookRepository.Read(bookId);
			if (book is null) throw new BookNotFoundException();
			book = user.ReadedBooks.Where(x => x.Id == bookId).FirstOrDefault();
			if (book is null) return false;
			return true;
		}
	}
}
