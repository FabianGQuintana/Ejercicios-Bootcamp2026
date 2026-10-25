using DevLights_Bloque1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevLights_Bloque1.Repositories
{
    public interface IProductoRepository
    {
        void Agregar(Producto producto);
        List<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id); 
        List<Producto> BuscarPorCategoria(string categoria);

    }
}
