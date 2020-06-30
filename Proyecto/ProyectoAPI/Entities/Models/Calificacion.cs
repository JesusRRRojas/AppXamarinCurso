using System;
using System.Collections.Generic;

namespace ProyectoAPI.Entities.Models
{
    public partial class Calificacion
    {
        public int IdRestaurant { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Puntaje { get; set; }
        public string Comentario { get; set; }
    }
}
