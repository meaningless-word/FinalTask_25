using FinalTask.PLL.Views;

namespace FinalTask
{
	class Program
	{
		public static MainMenu mainMenu;
		public static CatalogMenu catalogMenu;
		public static GenreMenu genreMenu;
		public static BookMenu bookMenu;
		public static UserMenu userMenu;
		public static OrderMenu orderMenu;
		public static AuthorMenu authorMenu;

		static void Main(string[] args)
		{
			mainMenu = new MainMenu();
			catalogMenu = new CatalogMenu();
			genreMenu = new GenreMenu();
			bookMenu = new BookMenu();
			userMenu = new UserMenu();
			orderMenu = new OrderMenu();
			authorMenu = new AuthorMenu();

			mainMenu.Choose();
		}
	}
}
