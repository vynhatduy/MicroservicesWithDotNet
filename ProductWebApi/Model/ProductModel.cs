using ProductWebApi.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductWebApi.Model
{
    public class ProductModel
    {
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string Url { get; set; }
        public double Gia { get; set; }
        public string ThanhPhan { get; set; }
        public string CongDung { get; set; }
        public string CachDung { get; set; }
        public int categoryId { get; set; }
    }
}
