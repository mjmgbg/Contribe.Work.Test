using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contribe.Ecommerce.Models.Interfaces
{
	public interface IBookstoreService
	{
		Task<IEnumerable<IBook>> GetBooksAsync(string searchString);

	}
}
