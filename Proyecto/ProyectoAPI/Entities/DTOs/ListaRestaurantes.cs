using ProyectoAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAPI.Entities.DTOs
{
    public class ListaRestaurantes
    {
        public int IdRestaurant { get; set; }
        public string NombreRestaurant { get; set; }
        public string DescripcionRestaurant { get; set; }
        public string DireccionRestaurant { get; set; }
        public string imagenRestaurant { get; set; }
        public bool FavoritoUsuario { get; set; }
        public List<CategoriaRes> Categorias { get; set; }
        public int TotalComentario { get; set; }
        public decimal PromedioCalificacion { get; set; }
    }
}
