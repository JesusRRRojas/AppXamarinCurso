using ProyectoAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAPI.Services
{
    public interface IUnitOfWork
    {
        IRepository<Categoria> Categorias { get; }
        IRepository<Favorito> Favoritos { get; }
        IRepository<Restaurant> Restaurantes { get; }
        IRepository<RestaurantCategoria> RestaurantesCategoria { get; }
        IRepository<Usuario> Usuarios { get; }
        void Save();



    }
}
