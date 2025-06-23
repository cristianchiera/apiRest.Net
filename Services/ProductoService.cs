using ApiRestEjemplo.Models;

namespace ApiRestEjemplo.Services
{
    public class ProductoService
    {
        private readonly List<Producto> _productos = new()
        {
            new Producto { Id = 1, Nombre = "Mate", Precio = 10.5M },
            new Producto { Id = 2, Nombre = "Termo", Precio = 20.0M }
        };

        public List<Producto> GetAll() => _productos;

        public Producto? GetById(int id) => _productos.FirstOrDefault(p => p.Id == id);

        public void Add(Producto producto) => _productos.Add(producto);

        public bool Update(int id, Producto producto)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.Nombre = producto.Nombre;
            existing.Precio = producto.Precio;
            return true;
        }

        public bool Delete(int id)
        {
            var producto = GetById(id);
            return producto != null && _productos.Remove(producto);
        }
    }
}
