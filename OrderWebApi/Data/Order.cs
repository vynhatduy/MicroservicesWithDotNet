using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderWebApi.Data
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("NgayTao")]
        [Required]
        public string Ngay { get; set; }
        [Column("TongTien")]
        [Required]
        [Range(0,double.MaxValue)]
        [DefaultValue(1000)]
        public double TongTien { get; set; }

    }
}
