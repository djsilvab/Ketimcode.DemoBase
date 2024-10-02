namespace Ketimcode.DemoBase.Api.Models;

public class Mandril
{
    public int Id { get; set;}
    public string? Name { get; set; }
    public string? Apellido { get; set;}
    public List<Habilidad> Habilidades { get; set; } = new List<Habilidad>();
}
