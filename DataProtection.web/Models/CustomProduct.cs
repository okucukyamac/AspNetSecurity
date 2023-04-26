using System.ComponentModel.DataAnnotations.Schema;

namespace DataProtection.web.Models
{
    public partial class Product
    {
        [NotMapped]
        public string EncrypedId { get; set; }
    }
}
