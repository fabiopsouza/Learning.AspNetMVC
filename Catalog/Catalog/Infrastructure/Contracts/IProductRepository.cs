using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Models;

namespace Catalog.Infrastructure.Contracts
{
    interface IProductRepository : IRepositoryBase<Product>
    {
    }
}
