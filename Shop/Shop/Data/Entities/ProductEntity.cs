using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Data.Entities
{
    [Table("tblProducts")]
    public class ProductEntity : BaseEntity<int>
    {
        [Required, StringLength(500)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Image { get; set; }
        public decimal Price { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
    }
}
