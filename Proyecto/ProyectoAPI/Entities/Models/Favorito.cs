using System;
using System.Collections.Generic;

namespace ProyectoAPI.Entities.Models
{
    public partial class Favorito
    {
        public int IdRestaurant { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Restaurant IdRestaurantNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
