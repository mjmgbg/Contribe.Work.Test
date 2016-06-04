using Contribe.Ecommerce.Models;
using Contribe.Ecommerce.Models.Interfaces;
using System;
using System.Linq;

namespace Contribe.Ecommerce.Data.Repositories
{

	public class AddressRepository : RepositoryBase<Address>, IAddressRepository<Address>
	{
		public AddressRepository(EcommerceContext context) : base(context)
		{
			if (context == null)
				throw new ArgumentNullException();
		}

		public Address GetByAddressAndZipCodeId(string street, string city)
		{
			return dbSet.FirstOrDefault(a => a.Street.ToLower().Equals(street.ToLower())
											 && a.City.ToLower().Equals(city.ToLower()));
		}
	}
}

