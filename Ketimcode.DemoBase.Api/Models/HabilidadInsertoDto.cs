using System.ComponentModel.DataAnnotations;

namespace Ketimcode.DemoBase.Api.Models;

public class HabilidadInsertoDto
{
    [Required]
    public string? Nombre { get; set; }
    public EPotencia Potencia { get; set; }
}
