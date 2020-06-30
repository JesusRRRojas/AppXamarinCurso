using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Data;
using ProyectoAPI.Entities.Models;
using ProyectoAPI.Services;

namespace ProyectoAPI.Controllers
{
    [Route("api/v1/XamarinCurso/[Controller]")]
    public class RestaurantesController : Controller
    {
        private dbaplicationContext _context = new dbaplicationContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new dbaplicationContext());

        [HttpGet("idUsuario")]
        public IActionResult GetAllRestaurant(int idUsuario)
        {
            var _listarestaurantes = new List<ListaRestaurantes>();

            var _restaurantes = new List<Restaurant>();
            var _listafavoritousaurio = new List<Favorito>();

            _restaurantes = ObtenerRestaurantes();
            _listafavoritousaurio = ObtenerFavoritos(idUsuario);

            foreach (var item in _restaurantes)
            {
                _listarestaurantes.Add(new ListaRestaurantes()
                {
                    IdRestaurant = item.IdRestaurant,
                    NombreRestaurant = item.Nombre,
                    DescripcionRestaurant = item.Descripcion,
                    DireccionRestaurant = item.Direccion,
                    //Categorias = _unitOfWork.Categorias.Get(x=>x.)
                });
            }

            return Ok(_listarestaurantes);
        }
        private void ObtenerCategorias(int idRestaurant)
        {

        }
        private List<Restaurant> ObtenerRestaurantes()
        {
            return _unitOfWork.Restaurantes.Get().
        }
        private List<Favorito> ObtenerFavoritos(int idusuario)
        {
            return _unitOfWork.Favoritos.Get(x => x.IdUsuario == idusuario).ToList();

        }
        private bool BuscarFavorito(List<Favorito> listaFavoritoUsuario, int idRestaurant)
        {
            return true;
        }
        // private List<Califi>

    }
}
