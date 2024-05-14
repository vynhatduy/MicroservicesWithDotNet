using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartWebApi.Data
{
    public class Cart
    {
        [Key]
        [Required]
        [Column("Username")]
        [MaxLength(100)]
        public string Username { get; set; }
        [Required]
        [Column("ProductId")]
        
        public int productId { get; set; }
        [Required]
        [Column("Ten")]
        public string Ten { get; set; }
        [Required]
        [Column("Url")]
        public string Url { get; set; }
        [Required]
        [Column("SoLuong")]
        [Range(0, int.MaxValue)]
        [DefaultValue(1)]

        public int SoLuong { get; set; }
        [Required]
        [Column("Gia")]
        [Range(0, double.MaxValue)]
        [DefaultValue(1000)]
        public double Gia { get; set; }
    }
}
