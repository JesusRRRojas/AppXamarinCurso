using System;
using System.Collections.Generic;

namespace ProyectoAPI.Entities.Models
{
    public partial class RestaurantCategoria
    {
        public int IdRestaurant { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Restaurant IdRestaurantNavigation { get; set; }
    }
}
