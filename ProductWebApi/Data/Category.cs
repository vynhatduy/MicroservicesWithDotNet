using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductWebApi.Data
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [MaxLength(100)]
        [Column("Ten")]
        [Required]
        public string Ten { get; set; }
        public string MoTa { get;set; }
    }
}
