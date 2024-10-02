using System;

namespace Ketimcode.DemoBase.Api.Models;

public enum EPotencia{
    Suave,
    Moderado,
    Intenso,
    RePotente,
    Extremo
}

public class Habilidad
{
    public int Id { get; set;}
    public string? Name { get; set; }
    public EPotencia Potencia { get; set; }
}


