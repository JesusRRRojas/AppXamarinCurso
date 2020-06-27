using System;
using System.Collections.Generic;

namespace ProyectoAPI.Entities.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            RestaurantCategoria = new HashSet<RestaurantCategoria>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }

        public virtual ICollection<RestaurantCategoria> RestaurantCategoria { get; set; }
    }
}
