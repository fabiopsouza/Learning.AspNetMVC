using System.ComponentModel.DataAnnotations;

namespace Catalog.Models
{
    public class WaitViewModel
    {
        [Required(ErrorMessage = "Insira um valor")]
        public string Value { get; set; } 
    }
}