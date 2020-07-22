using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionMovil.Model
{
    public class ListaRestaurantes : DatosRestaurant
    {

        public bool FavoritoUsuario { get; set; }
        public List<CategoriaRes> Categorias { get; set; }
        public int TotalComentario { get; set; }
        public decimal PromedioCalificacion { get; set; }
    }
}
