using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDotNet.WebMVC.Models.EF
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
        [MaxLength(250)]
        [Display(Name = "Tên danh mục")]
        public string Name { set; get; }

        [MaxLength(500)]
        [Display(Name = "Mô tả")]
        public string Description { set; get; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}