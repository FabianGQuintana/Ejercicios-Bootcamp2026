using BL.DTOs;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BL.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repositorio;

    public ProductoService(IProductoRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public List<ProductoDto> ObtenerTodos()
    {
        return _repositorio.ObtenerTodos().Select(ToDto).ToList();
    }

    public ProductoDto? ObtenerPorId(int id)
    {
        Producto? producto = _repositorio.ObtenerPorId(id);
        return producto == null ? null : ToDto(producto);
    }

    public ProductoDto Crear(CreateProductoDto dto)
    {
        Producto producto = new Producto
        {
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            Categoria = dto.Categoria,
            Activo = true
        };

        _repositorio.Agregar(producto);
        return ToDto(producto);
    }

    public ProductoDto? Actualizar(int id, CreateProductoDto dto)
    {
        Producto? existente = _repositorio.ObtenerPorId(id);
        if (existente == null)
        {
            return null;
        }

        existente.Nombre = dto.Nombre;
        existente.Precio = dto.Precio;
        existente.Categoria = dto.Categoria;
        _repositorio.Actualizar(existente);

        return ToDto(existente);
    }

    public bool Eliminar(int id)
    {
        return _repositorio.Eliminar(id);
    }

    private static ProductoDto ToDto(Producto producto)
    {
        return new ProductoDto
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Categoria = producto.Categoria,
            Activo = producto.Activo
        };
    }
}
