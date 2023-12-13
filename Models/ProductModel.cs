using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Alena.Models
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column(TypeName = "text")]
        public string productThumbnai { get; set; }
        public string productName { get; set; }
        public double? productCurrentPrice { get; set; }
        public double? productOldPrice { get; set; }
        public bool isSoldOut { get; set; } = false;
        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public CategoryModel categories { get; set; }
    }
}
