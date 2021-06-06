using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask.BLL.Models
{
	public class BookDTO
	{
		public int? Id { get; set; }
		public string Title { get; set; }
		public int YearOfIssue { get; set; }
		public string Authors { get; set; }
		public string Genre { get; set; }

		public BookDTO() { }
		public BookDTO (int? Id, string Title, int YearOfIssue, string Authors, string Genre)
		{
			this.Id = Id;
			this.Title = Title;
			this.YearOfIssue = YearOfIssue;
			this.Authors = Authors;
			this.Genre = Genre;
		}
	}
}
