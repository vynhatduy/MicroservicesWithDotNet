using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductWebApi.Data
{
    public class Product
    {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        [Column("Ten")]
        public string Ten { get; set; } = null!;
        [MaxLength(500)]
        [Column("MoTa")]
        public string MoTa { get; set; }
        [MaxLength(500)]
        [Required]
        [Column("HinhAnh")]
        public string Url { get; set; } = null!;
        [Required]
        [Range(0, double.MaxValue)]
        [DefaultValue(1000)]
        [Column("Gia")]
        public double Gia { get; set; }
        [Column("ThanhPhan")]
        public string ThanhPhan { get; set; }
        [Column("CongDung")]
        public string CongDung {get; set; }
        [Column("CachDung")]
        public string CachDung { get; set; }
        [ForeignKey("categoryId")]
        [Required]
        public int categoryId { get; set; }
        public Category Category { get; set; }
    }
}
