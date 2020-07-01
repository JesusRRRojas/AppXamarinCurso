using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAPI.Entities.DTOs
{
    public class ListaFavoritos
    {
        public int IdUsuario { get; set; }
        public List<DatosRestaurant> MiListaRestaurantes { get; set; }
    }
}
