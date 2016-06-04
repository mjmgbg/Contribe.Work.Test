using Antlr.Runtime.Misc;
using Contribe.Ecommerce.Data;
using Contribe.Ecommerce.Models;
using Contribe.Ecommerce.Models.Interfaces;
using Contribe.Ecommerce.Services;
using Contribe.Ecommerce.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Contribe.Ecommerce.Web.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public ShoppingCartController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		private IShoppingCartService GetCart()
		{
			var cart = (IShoppingCartService)Session["Cart"];
			if (cart != null) return cart;
			cart = new ShoppingCartService(new ListStack<IShoppingCartItem>());
			Session["Cart"] = cart;
			return cart;
		}

		public ActionResult Index(string returnUrl)
		{
			return PartialView("_Index", new ShoppingCartViewModel
			{
				ReturnUrl = returnUrl,
				Cart = GetCart(),
			});
		}

		public PartialViewResult AddToCartWidget(int id, string returnUrl)
		{
			var books = new List<Book>();
			books = _unitOfWork.Books.GetAll().ToList();

			var book = books.Find(b => b.BookId == id);
			if (book != null)
			{
				GetCart().AddItem(book, 1);
			}
			return PartialView("_CartWidget");
		}

		public PartialViewResult ReloadCartWidget()
		{
			return PartialView("_CartWidget");
		}

		public RedirectToRouteResult RemoveFromCart(int id, string returnUrl)
		{
			GetCart().Remove(id);
			return RedirectToAction("Index", new { returnUrl });
		}

		public RedirectToRouteResult EditQuantity(int id, string returnUrl, int quantity)
		{
			GetCart().Edit(id, quantity);
			return RedirectToAction("Index", new { returnUrl });
		}

		public PartialViewResult OrderDetails()
		{
			var model = new ContactViewModel();
			return PartialView("_OrderDetails", model);
		}


		[HttpPost]
		public ActionResult ProcessOrder(ContactViewModel contactModel, string returnUrl)
		{
			if (!ModelState.IsValid) return PartialView("_OrderDetails", contactModel);
			var cart = GetCart();
			var model = new CreateOrderViewModel
			{
				Cart = cart,
				OrderInfo = contactModel,

			};
			model.OrderInfo.Comment = contactModel.Comment;
			var orderService = new OrderService(_unitOfWork);
			var isSaved = orderService.ProcessOrder(contactModel.Address, contactModel.Contact, cart, contactModel.Comment);
			if (!isSaved)
			{
				contactModel.ErrorMessage = "Kunde inte spara uppgifterna försök igen!";
				return PartialView("_OrderDetails", contactModel);
			}
			model.Cart = cart.CreateCopy();

			cart.Clear();
			return PartialView("_ThankYou", model);
		}
	}
}