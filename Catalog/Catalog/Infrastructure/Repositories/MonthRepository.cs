using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Catalog.Infrastructure.Contracts;
using Catalog.Models;

namespace Catalog.Infrastructure.Repositories
{
    public class MonthRepository : RepositoryBase<Month>
    {
        public Month GetByName(string name)
        {
            return (from month in Ctx.Months where month.MonthName.Equals(name) select month).FirstOrDefault();
        }
    }
}