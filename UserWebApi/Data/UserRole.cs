using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserWebApi.Data
{
    public class UserRole
    {
        [ForeignKey("UserId")]
        [Required]
        [Column("UserId")]
        public int UserId {  get; set; }
        [ForeignKey("RoleId")]
        [Required]
        [Range(1,3)]
        [Column("RoleId")]
        [DefaultValue(3)]
        public int RoleId {  get; set; }
        [Required]
        [Column("UserName")]
        [MaxLength(255)]
        [Key]
        public string Usename { get;set; }
        [Required]
        [Column("Password")]
        [MaxLength(255)]
        public string Password { get; set; }
        [Required]
        [Column("Salt")]
        public string Salt { get; set; }

    }
}
