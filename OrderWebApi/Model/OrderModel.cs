using OrderWebApi.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrderWebApi.Model
{
    public class OrderModel
    {
        public int UserId { get; set; }
        public string Ngay { get; set; }
        public double TongTien { get; set; }
    }
}
