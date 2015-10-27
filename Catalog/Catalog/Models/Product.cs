using System.Web;

namespace Catalog.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Preco { get; set; }

        public byte[] Photo { get; set; }
    }
}