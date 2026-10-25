using System;
using System.Collections.Generic;
using System.Text;

namespace DevLights_Bloque1.Models
{
    public class Producto
    {
        public  int Id {  get; set; }
        public  string Name { get; set; } = string.Empty;
        public  decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public  bool Active { get; set; }   
    }
}
