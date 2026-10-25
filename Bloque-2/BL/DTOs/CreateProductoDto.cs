using System.ComponentModel.DataAnnotations;

namespace BL.DTOs;

public class CreateProductoDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [Range(0.01, 1000000)]
    public decimal Precio { get; set; }

    [Required]
    public string Categoria { get; set; } = string.Empty;
}
