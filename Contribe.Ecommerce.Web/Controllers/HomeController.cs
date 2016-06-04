using System.Linq;
using Contribe.Ecommerce.Data;
using Contribe.Ecommerce.Web.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;
using Contribe.Ecommerce.Models;
using Contribe.Ecommerce.Models.Interfaces;

namespace Contribe.Ecommerce.Web.Controllers
{
	public class HomeController : Controller
	{
		private IUnitOfWork _unitOfWork;
		private IBookstoreService _bookService;

		public HomeController(IUnitOfWork unitOfWork, IBookstoreService bookService)
		{
			_unitOfWork = unitOfWork;
			_bookService = bookService;

		}

		public async Task<ActionResult> Index()
		{
			var model = new StartPageViewModel
			{
				BookList = await _bookService.GetBooksAsync(null)
			};
			return View(model);
		}
		[HttpPost]
		public async Task<PartialViewResult> Search(StartPageViewModel model)
		{
			model.BookList = await _bookService.GetBooksAsync(model.SearchTerm);
			if (!model.BookList.Any()){model.NoSearchResultFound = true;}
			return PartialView("_bookslist", model);
		}

		public async Task<PartialViewResult> ReloadStartPage()
		{
			var model = new StartPageViewModel { BookList = await _bookService.GetBooksAsync(null) };
			return PartialView("_bookslist", model);
		}

	}
}