
using DevLights_Bloque1.Models; 
using DevLights_Bloque1.Repositories;

IProductoRepository repo = new ProductoRepository();

// 1. Mostrar todos los productos.
Console.WriteLine("=== TODOS LOS PRODUCTOS ===");

foreach (Producto producto in repo.ObtenerTodos())
{
    Console.WriteLine(
        $"ID: {producto.Id} | " +
        $"Nombre: {producto.Name} | " +
        $"Precio: ${producto.Price} | " +
        $"Categoría: {producto.Category} | " +
        $"Activo: {producto.Active}"
    );
}

// 2. Buscar un producto por ID.
Console.WriteLine("\n=== BUSCAR POR ID ===");

Producto? encontrado = repo.ObtenerPorId(2);

if (encontrado != null)
{
    Console.WriteLine(
        $"Encontrado: {encontrado.Name} - ${encontrado.Price}"
    );
}
else
{
    Console.WriteLine("No se encontró el producto.");
}

// 3. Buscar productos por categoría.
Console.WriteLine("\n=== BUSCAR POR CATEGORÍA ===");

List<Producto> productosElectronica =
    repo.BuscarPorCategoria("Electrónica");

foreach (Producto producto in productosElectronica)
{
    Console.WriteLine($"{producto.Name} - ${producto.Price}");
}

// 4. Agregar un nuevo producto.
Console.WriteLine("\n=== AGREGAR PRODUCTO ===");

Producto nuevoProducto = new Producto
{
    Id = 5,
    Name = "Auriculares",
    Price = 35000m,
    Category = "Electrónica",
    Active = true
};

repo.Agregar(nuevoProducto);

Console.WriteLine($"Producto agregado: {nuevoProducto.Name}");

// Verificar que se actualizo.
Console.WriteLine("\n=== LISTA ACTUALIZADA ===");

foreach (Producto producto in repo.ObtenerTodos())
{
    Console.WriteLine($"{producto.Id} - {producto.Name}");
}