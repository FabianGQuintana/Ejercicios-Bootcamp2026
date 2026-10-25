using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories;

public class ProductoRepositoryInMemory : IProductoRepository
{
    private readonly List<Producto> _productos;
    private int _siguienteId;

    public ProductoRepositoryInMemory()
    {
        _productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Teclado", Precio = 25000m, Categoria = "Electrónica", Activo = true },
            new Producto { Id = 2, Nombre = "Monitor HD", Precio = 450000m, Categoria = "Electrónica", Activo = true },
            new Producto { Id = 3, Nombre = "Arroz 1kg", Precio = 1500m, Categoria = "Alimentos", Activo = true },
            new Producto { Id = 4, Nombre = "Fideos", Precio = 1200m, Categoria = "Alimentos", Activo = false }
        };
        _siguienteId = _productos.Max(p => p.Id) + 1;
    }

    public List<Producto> ObtenerTodos()
    {
        return _productos.ToList();
    }

    public Producto? ObtenerPorId(int id)
    {
        return _productos.FirstOrDefault(p => p.Id == id);
    }

    public void Agregar(Producto producto)
    {
        producto.Id = _siguienteId++;
        _productos.Add(producto);
    }

    public bool Actualizar(Producto producto)
    {
        int indice = _productos.FindIndex(p => p.Id == producto.Id);
        if (indice == -1)
        {
            return false;
        }

        _productos[indice] = producto;
        return true;
    }

    public bool Eliminar(int id)
    {
        return _productos.RemoveAll(p => p.Id == id) > 0;
    }
}
