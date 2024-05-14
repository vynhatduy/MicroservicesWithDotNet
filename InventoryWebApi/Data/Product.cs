using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryWebApi.Data
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [Column("Ten")]
        [MaxLength(100)]
        public string Ten { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        [DefaultValue(1)]
        public int SoLuong { get;set; }
    }
}
