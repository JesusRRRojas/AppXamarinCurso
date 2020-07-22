using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionMovil.Model
{
    public class ListaFavoritos
    {
        public int IdUsuario { get; set; }
        public List<DatosRestaurant> MiListaRestaurantes { get; set; }
    }
}
