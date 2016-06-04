using Contribe.Ecommerce.Data;
using Contribe.Ecommerce.Models;
using Contribe.Ecommerce.Models.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Contribe.Ecommerce.Services
{


	public class BookstoreService : IBookstoreService
	{
		private readonly IUnitOfWork _unitOfWork;

		public BookstoreService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		private IEnumerable<IBook> ManageBooksFromApi(string url)
		{

			var booksFromUrl = GetInfoFromApiAsync(url);
			var booksList = ConvertJsonStringToList(booksFromUrl);
			var booksToAdd = GetBooksNotInDb(booksList);
			SaveApiBooksToDb(booksToAdd);
			return _unitOfWork.Books.GetAll();
		}

		private void SaveApiBooksToDb(IEnumerable<IBook> booksToAdd)
		{
			if (booksToAdd == null) return;
			if (!booksToAdd.Any()) return;

			foreach (var book in booksToAdd)
			{
				_unitOfWork.Books.Insert(book as Book);
			}
			_unitOfWork.Save();
		}

		private string GetInfoFromApiAsync(string url)
		{
			{
				using (var client = new WebClient())
				{
					client.Encoding = Encoding.UTF8;
					try
					{
						return client.DownloadString(url);
					}
					catch (System.Net.WebException)
					{
						return "Could not download from url";
					}
				}
			}
		}

		private IEnumerable<IBook> ConvertJsonStringToList(string jsonString)
		{
			var root = JsonConvert.DeserializeObject<JsonRootObject>(jsonString);
			return root.Books;
		}

		private IEnumerable<IBook> GetBooksNotInDb(IEnumerable<IBook> booksFromApi)
		{
			var booksFromDb = _unitOfWork.Books.GetAll().ToList();
			return booksFromApi.Except(booksFromDb).ToList();
		}

		public async Task<IEnumerable<IBook>> GetBooksAsync(string searchString)
		{
			var booksFromDb = await GetBooksPopulateIfEmpty();
			if (string.IsNullOrWhiteSpace(searchString)) return booksFromDb.ToList();
			var quyeryString = searchString.ToLower();
			booksFromDb = booksFromDb.Where(b =>
				b.Title.ToLower().Contains(quyeryString) ||
				b.Author.ToLower().Contains(quyeryString));
			return booksFromDb.ToList();
		}

		private async Task<IEnumerable<IBook>> GetBooksPopulateIfEmpty()
		{
			var booksFromDb = await _unitOfWork.Books.GetAllAsync() as IEnumerable<IBook>;
			if (!booksFromDb.Any())
			{
				var clientUrl = ConfigurationManager.AppSettings["ClientUrl"];
				booksFromDb = ManageBooksFromApi(clientUrl);
			}
			return booksFromDb;
		}
	}
}
