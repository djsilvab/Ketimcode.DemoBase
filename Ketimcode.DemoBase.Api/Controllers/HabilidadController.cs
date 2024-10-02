using Ketimcode.DemoBase.Api.Helpers;
using Ketimcode.DemoBase.Api.Models;
using Ketimcode.DemoBase.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ketimcode.DemoBase.Api.Controllers;

[ApiController]
[Route("api/mandril/{idmandril}/[controller]")]
public class HabilidadController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Habilidad>> GetAll(int idmandril)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(x => x.Id.Equals(idmandril));
        if(mandril == null) return NotFound(Mensajes.Mandril.NotFound);
        
        return Ok(mandril.Habilidades);
    }

    [HttpGet("{id}")]
    public ActionResult<Habilidad> GetOne(int idmandril, int id)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(x => x.Id.Equals(idmandril));
        if(mandril == null) return NotFound(Mensajes.Mandril.NotFound);

        var habilidad = mandril.Habilidades?.FirstOrDefault(x => x.Id.Equals(id));
        if(habilidad == null) return NotFound(Mensajes.Habilidad.NotFound);

        return Ok(habilidad);
    }

    [HttpPost]
    public ActionResult<Habilidad> Create(int idmandril, HabilidadInsertoDto habilidadInsertoDto)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(x => x.Id.Equals(idmandril));
        if(mandril == null) return NotFound(Mensajes.Mandril.NotFound);

        if(mandril.Habilidades.Any(x => x.Name == habilidadInsertoDto.Nombre )) return BadRequest(Mensajes.Habilidad.ExisteHabilidad);

        var idMax = mandril.Habilidades?.Max(x => x.Id)??0;

        var newHabilidad = new Habilidad
        {
            Id = idMax + 1,
            Name = habilidadInsertoDto.Nombre,
            Potencia = habilidadInsertoDto.Potencia
        };

        mandril.Habilidades?.Add(newHabilidad);

        return CreatedAtAction(nameof(GetOne), new { idmandril, id = newHabilidad.Id }, newHabilidad);

    }

    [HttpPut("{id}")]
    public ActionResult<Habilidad> Update(int idmandril, int id, HabilidadInsertoDto habilidadInsertoDto)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(x => x.Id.Equals(idmandril));
        if(mandril == null) return NotFound(Mensajes.Mandril.NotFound);

        var habilidad = mandril.Habilidades?.FirstOrDefault(x => x.Id == id);
        if(habilidad == null) return NotFound(Mensajes.Habilidad.NotFound);

        if(mandril.Habilidades?.Count(x => x.Id != id && x.Name == habilidadInsertoDto.Nombre ) > 0) return BadRequest(Mensajes.Habilidad.ExisteHabilidad);

        habilidad.Name = habilidadInsertoDto.Nombre;
        habilidad.Potencia = habilidadInsertoDto.Potencia;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult<Habilidad> Delete(int idmandril, int id)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(x => x.Id.Equals(idmandril));
        if(mandril == null) return NotFound(Mensajes.Mandril.NotFound);

        var habilidad = mandril.Habilidades?.FirstOrDefault(x => x.Id == id);
        if(habilidad == null) return NotFound(Mensajes.Habilidad.NotFound);

        mandril.Habilidades?.Remove(habilidad);

        return NoContent();
    }

}
