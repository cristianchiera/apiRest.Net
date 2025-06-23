using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestEjemplo.Models;
using ApiRestEjemplo.Data;

namespace ApiRestEjemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SujetoActividadController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SujetoActividadController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sujeto_actividad = await _context.SujetoActividad.ToListAsync();
            return Ok(sujeto_actividad);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sujeto = await _context.SujetoActividad.FindAsync(id);
            if (sujeto == null)
                return NotFound();
            return Ok(sujeto);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar([FromQuery] string? apellido)
        {
            var query = _context.SujetoActividad.AsQueryable();

            if (!string.IsNullOrEmpty(apellido))
                query = query.Where(s => s.apellido != null && 
                                         s.apellido.ToLower().Contains(apellido.ToLower()));

            var resultados = await query.ToListAsync();
            return Ok(resultados);
        }
        
        [HttpGet("cuil")]
        public async Task<IActionResult> cuil([FromQuery] string? cuil)
        {
            var query = _context.SujetoActividad.AsQueryable();

            if (!string.IsNullOrEmpty(cuil))
                query = query.Where(o => o.cuil == cuil);

            var resultados = await query.ToListAsync();
            return Ok(resultados);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] SujetoActividadPatchDto dto)
        {
            var sujeto = await _context.SujetoActividad.FindAsync(id);
            if (sujeto == null)
                return NotFound();

            if (dto.apellido != null) sujeto.apellido = dto.apellido;
            if (dto.nombres != null) sujeto.nombres = dto.nombres;
            if (dto.email != null) sujeto.email = dto.email;
            if (dto.telefono != null) sujeto.telefono = dto.telefono;
            if (dto.cuil != null) sujeto.cuil = dto.cuil;
            if (dto.razon_social != null) sujeto.razon_social = dto.razon_social;
            if (dto.domicilio_real != null) sujeto.domicilio_real = dto.domicilio_real;
            if (dto.dni.HasValue) sujeto.dni = dto.dni.Value;
            if (dto.sujeto_actividad_id.HasValue) sujeto.sujeto_actividad_id = dto.sujeto_actividad_id.Value;
            if (dto.tipo_persona_id !=null) sujeto.tipo_persona_id = dto.tipo_persona_id;
            if (dto.departamento_id !=null) sujeto.departamento_id = dto.departamento_id;
            if (dto.isactive.HasValue) sujeto.isactive = dto.isactive.Value;
            // Repite para todos los campos de tu modelo

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SujetoActividad nuevo)
        {
            _context.SujetoActividad.Add(nuevo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = nuevo.id }, nuevo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sujeto = await _context.SujetoActividad.FindAsync(id);
            if (sujeto == null)
                return NotFound();

            _context.SujetoActividad.Remove(sujeto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("relaciones")]
        public async Task<IActionResult> GetRelaciones()
        {
            var query = from sai in _context.SujetoActividad
                        where sai.relacion_tipo_id != null
                        join rt in _context.RelacionTipo 
                            on Convert.ToInt32(sai.relacion_tipo_id) equals Convert.ToInt32(rt.relacion_tipo_id)
                        select new SujetoActividadRelacionDto
                        {
                            id = sai.id ?? 0, // porque id también es nullable
                            cuil = sai.cuil,
                            descripcion = rt.descripcion
                        };

            var lista = await query.ToListAsync();
            return Ok(lista);
        }


        [HttpGet("relaciones/{id}")]
        public async Task<IActionResult> GetRelacionPorId(int id)
        {
            var query = from sai in _context.SujetoActividad
                        where sai.relacion_tipo_id != null && sai.id == id
                        join rt in _context.RelacionTipo 
                            on Convert.ToInt32(sai.relacion_tipo_id) equals Convert.ToInt32(rt.relacion_tipo_id)
                        select new SujetoActividadRelacionDto
                        {
                            id = sai.id ?? 0,
                            cuil = sai.cuil,
                            descripcion = rt.descripcion
                        };

            var resultado = await query.FirstOrDefaultAsync();
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }


    }
}