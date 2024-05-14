using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UserWebApi.Model
{
    public class UserRoleModel
    {
        public int UserId { get; set; }
        public string Usename { get; set; }
        public string Password { get; set; }
    }
}
