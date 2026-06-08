using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities
{
    [Table("agencias_tb")]
    public class Agencia
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(100)]
        public string City { get; set; } = string.Empty;

        [StringLength(2)]
        public string State { get; set; } = string.Empty;
    }
}
