using Ketimcode.DemoBase.Api.Models;

namespace Ketimcode.DemoBase.Api.Services;

public class MandrilDataStore
{
    public List<Mandril>? Mandriles { get; set; }

    public static MandrilDataStore Current{ get;} = new MandrilDataStore();

    public MandrilDataStore()
    {
        this.Mandriles = new List<Mandril>(){
            new Mandril{
                Id = 1,
                Name = "Mini Mandril",
                Apellido = "Rodriguez",
                Habilidades = new List<Habilidad>{
                    new Habilidad{
                        Id = 1,
                        Name = "Saltar",
                        Potencia = EPotencia.Intenso
                    }
                }
            },
            new Mandril{
                Id = 2,
                Name = "Supermandril",
                Apellido = "Fernandez",
                Habilidades = new List<Habilidad>{
                    new Habilidad{
                        Id = 1,
                        Name = "Saltar",
                        Potencia = EPotencia.Moderado
                    },
                    new Habilidad{
                        Id = 2,
                        Name="Caminar",
                        Potencia = EPotencia.Intenso
                    },
                    new Habilidad{
                        Id = 3,
                        Name="Gritar",
                        Potencia = EPotencia.RePotente
                    }
                }
            },
            new Mandril{
                Id = 3,
                Name = "Megamandril",
                Apellido = "Legrand",
                Habilidades = new List<Habilidad>{
                    new Habilidad{
                        Id = 1,
                        Name = "Nadar",
                        Potencia = EPotencia.Intenso
                    },
                    new Habilidad{
                        Id = 2,
                        Name = "Correr",
                        Potencia = EPotencia.Extremo
                    },
                    new Habilidad{
                        Id = 3,
                        Name = "Vomitar",
                        Potencia = EPotencia.RePotente
                    }
                }
            }
        };
    }
}
