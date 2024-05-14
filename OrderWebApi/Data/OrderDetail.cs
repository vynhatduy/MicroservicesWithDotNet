using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderWebApi.Data
{
    public class OrderDetail
    {
        [Required]
        [Column("OrderId")]
        public int orderId { get; set; }
        [Required]
        [Column("ProductId")]
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        [DefaultValue(1)]
        [Column("SoLuong")]
        public int SoLuong { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        [DefaultValue(1000)]
        [Column("ThanhTien")]
        public double ThanhTien { get; set; }
    }
}
