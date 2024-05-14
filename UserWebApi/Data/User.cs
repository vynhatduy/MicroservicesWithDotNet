using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserWebApi.Data
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [Column("HoTen")]
        [MaxLength(100)]
        public string HoTen { get; set; }
        [Required]
        [MaxLength(10)]
        [Column("SoDienThoai")]
        [DefaultValue("0123456789")]
        public string SDT { get;set; }
        [Column("DiaChi")]
        public string DiaChi { get; set; }
    }
}
