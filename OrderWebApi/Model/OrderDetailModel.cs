using OrderWebApi.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrderWebApi.Model
{
    public class OrderDetailModel
    {
        public int orderId { get; set; }
        public int ProductId { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien { get; set; }
    }
}
