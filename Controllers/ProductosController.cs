using Microsoft.AspNetCore.Mvc;
using ApiRestEjemplo.Models;
using ApiRestEjemplo.Services;

namespace ApiRestEjemplo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductosController(ProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Producto>> Get() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var prod = _service.GetById(id);
            return prod == null ? NotFound() : Ok(prod);
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            _service.Add(producto);
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Producto producto)
        {
            if (!_service.Update(id, producto)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.Delete(id)) return NotFound();
            return NoContent();
        }
    }
}
