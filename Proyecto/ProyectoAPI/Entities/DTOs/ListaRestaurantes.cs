using ProyectoAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAPI.Entities.DTOs
{
    public class ListaRestaurantes : DatosRestaurant
    {
      
        public bool FavoritoUsuario { get; set; }
        public List<CategoriaRes> Categorias { get; set; }
        public int TotalComentario { get; set; }
        public decimal PromedioCalificacion { get; set; }
    }
}
