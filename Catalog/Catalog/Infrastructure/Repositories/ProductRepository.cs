using System.Collections.Generic;
using System.Linq;
using Catalog.Infrastructure.Contracts;
using Catalog.Models;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public List<Product> Get(string sort, bool sortReverse, string searchFor)
        {
            var query = from x in Ctx.Products where x.Name.Contains(searchFor) || x.Description.Contains(searchFor) select x;

            switch (sort)
            {
                case "Name":
                    query = sortReverse ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
                    break;
                case "Description":
                    query = sortReverse ? query.OrderByDescending(x => x.Description) : query.OrderBy(x => x.Description);
                    break;
                case "Preco":
                    query = sortReverse ? query.OrderByDescending(x => x.Preco) : query.OrderBy(x => x.Preco);
                    break;
            }

            return query.ToList();
        }
    }
}