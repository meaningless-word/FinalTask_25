namespace FinalTask.BLL.Models
{

	public class AuthorDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public AuthorDTO() { }

		public AuthorDTO(int Id, string Name)
		{
			this.Id = Id;
			this.Name = Name;
		}
	}
}
