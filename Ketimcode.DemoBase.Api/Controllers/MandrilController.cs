using Ketimcode.DemoBase.Api.Helpers;
using Ketimcode.DemoBase.Api.Models;
using Ketimcode.DemoBase.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ketimcode.DemoBase.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MandrilController : ControllerBase
{
    public MandrilController()
    {
        
    }

    [HttpGet]
    public ActionResult<IEnumerable<Mandril>> GetAll()
    {
        return Ok(MandrilDataStore.Current.Mandriles);
    }

    [HttpGet("{id}")]
    public ActionResult<Mandril> GetOne(int id)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(x => x.Id.Equals(id));
        if(mandril == null) return NotFound(Mensajes.Mandril.NotFound);
        return Ok(mandril);
    }

    [HttpPost]
    public ActionResult<Mandril> Create(MandrilInsertDto mandrilDto)
    {
        var IdMax = MandrilDataStore.Current.Mandriles?.Max(x => x.Id)??0;
        var newMandril = new Mandril{
            Id = IdMax+1,
            Name = mandrilDto.Nombre,
            Apellido = mandrilDto.Apellido,
        };

        MandrilDataStore.Current.Mandriles?.Add(newMandril);
        return CreatedAtAction(nameof(GetOne), new { id = newMandril.Id }, newMandril);
    }

    [HttpPut("{id}")]
    public ActionResult<Mandril> Update([FromRoute] int id,[FromBody] MandrilInsertDto mandrilUpdateDto)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(x => x.Id.Equals(id));
        if(mandril == null) return NotFound(Mensajes.Mandril.NotFound);

        mandril.Name = mandrilUpdateDto.Nombre;
        mandril.Apellido = mandrilUpdateDto.Apellido;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult<Mandril> Delete(int id)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(x => x.Id.Equals(id));
        if(mandril == null) return NotFound(Mensajes.Mandril.NotFound);

        MandrilDataStore.Current.Mandriles?.Remove(mandril);

        return NoContent();
    }

}
