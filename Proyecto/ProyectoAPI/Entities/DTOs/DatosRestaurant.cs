using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAPI.Entities.DTOs
{
    public class DatosRestaurant
    {
        public int IdRestaurant { get; set; }
        public string NombreRestaurant { get; set; }
        public string DescripcionRestaurant { get; set; }
        public string DireccionRestaurant { get; set; }
        public string ImagenRestaurant { get; set; }
    }
}
