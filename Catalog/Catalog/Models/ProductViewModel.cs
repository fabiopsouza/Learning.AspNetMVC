using System.Drawing;
using System.Web;

namespace Catalog.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Preco { get; set; }

        public HttpPostedFile PhotoInput { get; set; }

        public string PhotoOutput { get; set; }
    }
}