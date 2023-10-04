using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiKey.Models;


[Table("ApiKey")]
public class ApiKeyModel
{
    [Key]
    [StringLength(128)]
    [Column(TypeName = "nvarchar")]
    string KeyId { get; set; } = default!;
    bool Status { get; set; } = true;
    [Required]
    string Permissions { get; set; } = default!;
}