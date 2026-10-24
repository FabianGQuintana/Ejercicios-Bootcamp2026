using System;
using System.Collections.Generic;
using System.Text;
using DevLights_Bloque1.Models; 

namespace DevLights_Bloque1.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly List<Producto> _productos;

        public ProductoRepository()
        {
            _productos = new List<Producto>
            {
                new Producto
                {
                     Id = 1,
                    Name = "Teclado",
                    Price = 25000m,
                    Category = "Electrónica",
                    Active = true
                },
                new Producto
                {
                    Id = 2,
                    Name = "Monitor HD",
                    Price = 450000m,
                    Category = "Electrónica",
                    Active = true
                },
                new() //La simplificada pero es muy raro.
                {
                     Id = 3,
                    Name = "Arroz 1kg",
                    Price = 1800m,
                    Category = "Alimentos",
                    Active = true
                },
                new()
                {
                    Id = 4,
                    Name = "Fideos",
                    Price = 2500m,
                    Category = "Alimentos",
                    Active = true
                }
            };
        }  
        

        public void Agregar(Producto producto)
        {
            _productos.Add(producto);
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        public List<Producto> ObtenerTodos()
        {
            return _productos.ToList();
        }

        public List<Producto> BuscarPorCategoria(string categoria)
        {
            return _productos
                .Where(p => p.Category == categoria)
                .ToList();
        }


    }
}
