using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAPI.Entities.DTOs
{
    public class DatosCalificacion
    {
        public int IdRestaurant { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Puntaje { get; set; }
        public string Comentario { get; set; }
    }
}
