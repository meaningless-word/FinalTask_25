namespace FinalTask.BLL.Models
{
	public class GenreDTO
	{
		/// <summary>
		/// идентификатор
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// наименование
		/// </summary>
		public string Name { get; set; }

		public GenreDTO() { }

		public GenreDTO(int Id, string Name)
		{
			this.Id = Id;
			this.Name = Name;
		}
	}
}
