using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Models
{
    public class Client
    {
        public virtual string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}