using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserWebApi.Data
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Ten")]
        [Required]
        [MaxLength(100)]
        public string Ten { get; set; }
        public string MoTa { get;set; }
    }
}
