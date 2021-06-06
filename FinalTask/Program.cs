using FinalTask.BLL.Services;
using FinalTask.PLL.Views;

namespace FinalTask
{
	class Program
	{
		public static BookService bookService;
		public static GenreService genreService;
		public static AuthorService authorService;
		public static UserService userService;

		public static MainMenu mainMenu;
		public static CatalogMenu catalogMenu;
		public static GenreMenu genreMenu;
		public static BookMenu bookMenu;
		public static UserMenu userMenu;
		public static OrderMenu orderMenu;

		static void Main(string[] args)
		{
			bookService = new BookService();
			genreService = new GenreService();
			authorService = new AuthorService(); 
			userService = new UserService();

			mainMenu = new MainMenu();
			catalogMenu = new CatalogMenu();
			genreMenu = new GenreMenu();
			bookMenu = new BookMenu();
			userMenu = new UserMenu();
			orderMenu = new OrderMenu();

			mainMenu.Choose();
		}
	}
}
