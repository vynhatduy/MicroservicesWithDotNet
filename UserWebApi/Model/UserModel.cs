using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UserWebApi.Model
{
    public class UserModel
    {
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
    }
}
