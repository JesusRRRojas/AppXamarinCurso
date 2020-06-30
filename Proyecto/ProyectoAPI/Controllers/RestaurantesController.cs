using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoAPI.Data;
using ProyectoAPI.Entities.DTOs;
using ProyectoAPI.Entities.Models;
using ProyectoAPI.Services;

namespace ProyectoAPI.Controllers
{
    [Route("api/v1/XamarinCurso/[Controller]")]
    public class RestaurantesController : Controller
    {
        private dbaplicationContext _context = new dbaplicationContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new dbaplicationContext());

        //[HttpGet("idUsuario")]
        //public IActionResult GetAllRestaurant(int idUsuario)
        [HttpGet()]
        public IActionResult GetAllRestaurant()
        {
            int idUsuario = 0;
            try
            {
                var _listarestaurantes = new List<ListaRestaurantes>();

                var _restaurantes = new List<Restaurant>();
                var _listafavoritousaurio = new List<Favorito>();

                _restaurantes = ObtenerRestaurantes();
                _listafavoritousaurio = ObtenerFavoritos(idUsuario);

                foreach (var item in _restaurantes)
                {
                    var _favoritousuario = ObtenerFavoritos(idUsuario);
                    var _valoracion = ObtenerValoracionRestaurant(item.IdRestaurant);
                    _listarestaurantes.Add(new ListaRestaurantes()
                    {
                        IdRestaurant = item.IdRestaurant,
                        NombreRestaurant = item.Nombre,
                        DescripcionRestaurant = item.Descripcion,
                        DireccionRestaurant = item.Direccion,
                        Categorias = ObtenerListaCategorias(item.IdRestaurant),
                        FavoritoUsuario = BuscarFavorito(_favoritousuario, item.IdRestaurant),
                        imagenRestaurant = item.Imagen,
                        PromedioCalificacion = _valoracion.PuntajePromedio,
                        TotalComentario = _valoracion.TotalCalificacion

                    });
                }

                var seralizando = JsonConvert.SerializeObject(_listarestaurantes,Formatting.Indented, new JsonSerializerSettings() {  ReferenceLoopHandling = ReferenceLoopHandling.Serialize});


                return Ok(seralizando);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        private ValoracionRestaurant ObtenerValoracionRestaurant(int idRestaurant)
        {
            var res = _unitOfWork.Calificaciones.Get(x => x.IdRestaurant == idRestaurant);
            int _contar = (from x in res select x.Puntaje).Count();
            decimal _total = (from x in res select x.Puntaje).Sum();
            decimal _promedio = _contar > 0 ? _total / _contar : 0;  
            return new ValoracionRestaurant() { PuntajePromedio = _promedio, TotalCalificacion = _contar};
        }

        private List<CategoriaRes> ObtenerListaCategorias(int idRestaurant)
        {
            List<CategoriaRes> _lista = new List<CategoriaRes>();
            var _rescat = ObtenerRestaurantCategoria(idRestaurant);
            foreach (var item in _rescat)
            {
                var res = ObtenerCategorias(item.IdCategoria).ToList();
                foreach (var _categoria in res)
                {
                    _lista.Add(new CategoriaRes() { IdCategoria = _categoria.IdCategoria, Imagen = _categoria.Imagen, Nombre = _categoria.Nombre });
                }
            }
            return _lista;
        }
        private List<Restaurant> ObtenerRestaurantes()
        {
            return _unitOfWork.Restaurantes.Get().ToList();
        }
        private List<RestaurantCategoria> ObtenerRestaurantCategoria(int idRestaurant)
        {
            return _unitOfWork.RestaurantesCategoria.Get(x => x.IdRestaurant == idRestaurant).ToList();
        }
        private List<Categoria> ObtenerCategorias(int idCatagoria)
        {
            return _unitOfWork.Categorias.Get(x => x.IdCategoria==idCatagoria).ToList();
        }
        private List<Favorito> ObtenerFavoritos(int idusuario)
        {
            return _unitOfWork.Favoritos.Get(x => x.IdUsuario == idusuario).ToList();

        }
        private bool BuscarFavorito(List<Favorito> listaFavoritoUsuario, int idRestaurant)
        {
            var res = (from x in listaFavoritoUsuario
                       where x.IdRestaurant == idRestaurant
                       select x).Count();
            return res == 0 ? false : true; 
        }


    }
}
