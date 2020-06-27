using System;
using System.Collections.Generic;

namespace ProyectoAPI.Entities.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Favorito = new HashSet<Favorito>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Favorito> Favorito { get; set; }
    }
}
