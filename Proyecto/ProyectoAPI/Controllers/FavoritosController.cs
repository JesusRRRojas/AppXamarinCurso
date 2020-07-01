using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using ProyectoAPI.Data;
using ProyectoAPI.Entities.DTOs;
using ProyectoAPI.Entities.Models;
using ProyectoAPI.Services;

namespace ProyectoAPI.Controllers
{
    [Route("api/v1/XamarinCurso/[Controller]")]
    public class FavoritosController : Controller
    {
        private dbaplicationContext _context = new dbaplicationContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new dbaplicationContext());


        [HttpGet]
        public IActionResult GetById([FromBody] DatosFavorito datofavorito)
        {
            int id = datofavorito.IdUsuario;
            try
            {
                ListaFavoritos MisFavoritos = new ListaFavoritos() 
                { 
                    IdUsuario = id, 
                    MiListaRestaurantes = new List<DatosRestaurant>()
                };

                var _favoritos = _unitOfWork.Favoritos.Get(f => f.IdUsuario == id).ToList();
                foreach (var _fav in _favoritos)
                {
                    var _favaux = _unitOfWork.Restaurantes.Get(x => x.IdRestaurant == _fav.IdRestaurant).FirstOrDefault();
                    if (_favaux != null)
                    {
                        MisFavoritos.MiListaRestaurantes.Add(GenerarDatosRestaurant(_favaux));
                    }
                }

                var MisFavoritosSeraizado = JsonConvert.SerializeObject(MisFavoritos);

                return Ok(MisFavoritosSeraizado);
            }
            catch (Exception ex )
            {
                return BadRequest($"Error {ex}");
            }


        }

        private DatosRestaurant GenerarDatosRestaurant(Restaurant restaurant)
        {
            return new DatosRestaurant()
            {
                DescripcionRestaurant = restaurant.Descripcion,
                DireccionRestaurant = restaurant.Direccion,
                IdRestaurant = restaurant.IdRestaurant,
                ImagenRestaurant = restaurant.Imagen,
                NombreRestaurant = restaurant.Nombre
            };
        }

        [HttpPost]
        public IActionResult PostFavorito([FromBody] DatosFavorito datofavorito)
        {
            try
            {
                var favorito = new Favorito()
                {
                    Fecha = DateTime.Now,
                    IdRestaurant = datofavorito.IdRestaurant,
                    IdUsuario = datofavorito.IdUsuario
                };

                _unitOfWork.Favoritos.Insert(favorito);
                _unitOfWork.Save();


                return Ok();
            }
            catch (Exception )
            {

                return BadRequest();
            }
           
        }

        [HttpDelete]
        public IActionResult DeleteFavorito([FromBody] DatosFavorito datofavorito)
        {
            try
            {
                var favorito = _unitOfWork.Favoritos.Get(x => x.IdRestaurant == datofavorito.IdRestaurant && x.IdUsuario == datofavorito.IdUsuario).FirstOrDefault();

                if (favorito == null)
                {
                    return BadRequest();
                }

                _unitOfWork.Favoritos.Delete(favorito);
                _unitOfWork.Save();

                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}
