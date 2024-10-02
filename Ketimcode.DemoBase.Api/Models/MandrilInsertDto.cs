using System.ComponentModel.DataAnnotations;

namespace Ketimcode.DemoBase.Api.Models;

public class MandrilInsertDto
{
    [Required]
    [MaxLength(50)]
    public string? Nombre { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string? Apellido { get; set; }
}
