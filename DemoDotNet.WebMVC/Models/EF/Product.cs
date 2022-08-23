using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDotNet.WebMVC.Models.EF
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(250)]
        public string Name { set; get; }

        [Required]
        public int CategoryID { set; get; }

        [MaxLength(500)]
        public string Image { set; get; }

        public decimal Price { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        public bool Status { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { set; get; }
    }
}