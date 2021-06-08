namespace FinalTask.BLL.Models
{
	public class UserDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public int ReadedBooksCount { get; set; }
		public int GivedBookId { get; set; }

		public UserDTO() { }

		public UserDTO(int Id, string Name, string Email, int ReadedBooksCount)
		{
			this.Id = Id;
			this.Name = Name;
			this.Email = Email;
			this.ReadedBooksCount = ReadedBooksCount;
		}
	}
}
