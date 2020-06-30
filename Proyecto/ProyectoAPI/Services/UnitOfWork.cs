using ProyectoAPI.Data;
using ProyectoAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ProyectoAPI.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private dbaplicationContext _context;
        private BaseRepository<Categoria> _categoria;
        private BaseRepository<Favorito> _favorito;
        private BaseRepository<Restaurant> _restaurant;
        private BaseRepository<RestaurantCategoria> _restaurantCategoria;
        private BaseRepository<Usuario> _usuario;
        private BaseRepository<Calificacion> _calificacion;

        public UnitOfWork(dbaplicationContext context)
        {
            _context = context;
        }
        public IRepository<Categoria> Categorias
        {
            get
            {
                return _categoria ?? (_categoria= new BaseRepository<Categoria>(_context));
            }
        }
        public IRepository<Favorito> Favoritos
        {
            get
            {
                return _favorito ?? (_favorito = new BaseRepository<Favorito>(_context));
            }
        }

        public IRepository<Restaurant> Restaurantes
        {
            get
            {
                return _restaurant ?? (_restaurant= new BaseRepository<Restaurant>(_context));
            }
        }

        public IRepository<RestaurantCategoria> RestaurantesCategoria
        {
            get
            {
                return _restaurantCategoria ?? (_restaurantCategoria = new BaseRepository<RestaurantCategoria>(_context));
            }
        }
        public IRepository<Usuario> Usuarios
        {
            get
            {
                return _usuario ?? (_usuario = new BaseRepository<Usuario>(_context));
            }
        }
        public IRepository<Calificacion> Calificaciones
        {
            get
            {
                return _calificacion ?? (_calificacion = new BaseRepository<Calificacion>(_context));
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
