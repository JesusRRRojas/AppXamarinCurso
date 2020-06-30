using System;
using System.Collections.Generic;

namespace ProyectoAPI.Entities.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Favorito = new HashSet<Favorito>();
            RestaurantCategoria = new HashSet<RestaurantCategoria>();
        }

        public int IdRestaurant { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }

        public string Imagen { get; set; }

        public virtual ICollection<Favorito> Favorito { get; set; }
        public virtual ICollection<RestaurantCategoria> RestaurantCategoria { get; set; }
    }
}
