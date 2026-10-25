using BL.DTOs;
using BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers;

[ApiController]
[Route("api/productos")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _servicio;

    public ProductosController(IProductoService servicio)
    {
        _servicio = servicio;
    }

    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        return Ok(_servicio.ObtenerTodos());
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        ProductoDto? producto = _servicio.ObtenerPorId(id);
        return producto == null ? NotFound() : Ok(producto);
    }

    [HttpPost]
    public IActionResult Crear(CreateProductoDto dto)
    {
        ProductoDto producto = _servicio.Crear(dto);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, CreateProductoDto dto)
    {
        ProductoDto? producto = _servicio.Actualizar(id, dto);
        return producto == null ? NotFound() : Ok(producto);
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        return _servicio.Eliminar(id) ? NoContent() : NotFound();
    }
}
