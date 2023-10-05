using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiKey.Models;


[Table("ApiKey")]
public class ApiKeyModel
{
    [Key]
    [StringLength(128)]
    [Column(TypeName = "nvarchar")]
    public string KeyId { get; set; } = default!;
    public bool Status { get; set; } = true;
    [Required]
    public string Permissions { get; set; } = default!;
}