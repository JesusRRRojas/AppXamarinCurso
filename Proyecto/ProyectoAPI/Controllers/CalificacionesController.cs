using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CalificacionesController : Controller
    {
        private dbaplicationContext _context = new dbaplicationContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new dbaplicationContext());


        [HttpGet("id")]
        public IActionResult GetById([FromHeader] int id)
        {
            try
            {
                var calres = _unitOfWork.Calificaciones.Get(x => x.IdRestaurant == id).ToList();
                var ListaCalificaciones = new List<DatosCalificacion>();
                foreach (var item in calres)
                {
                    ListaCalificaciones.Add(new DatosCalificacion()
                    {
                        Comentario = item.Comentario,
                        Fecha = item.Fecha,
                        IdRestaurant = item.IdRestaurant,
                        IdUsuario = item.IdUsuario,
                        Puntaje = item.Puntaje,
                        NombreUsuario = _unitOfWork.Usuarios.Get(x => x.IdUsuario == item.IdUsuario).FirstOrDefault().Nombre
                    });
                }
                var ListaSerializado = JsonConvert.SerializeObject(ListaCalificaciones);

                return Ok(ListaCalificaciones);
            }
            catch (Exception)
            {

                return BadRequest();
            }
          

        }
        [HttpPost]
        public IActionResult PostCalificacion([FromBody] DatosCalificacion datoscalificacion )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Calificacion cal = new Calificacion()
                    {
                        Comentario = datoscalificacion.Comentario,
                        Fecha = datoscalificacion.Fecha,
                        IdRestaurant = datoscalificacion.IdRestaurant,
                        IdUsuario = datoscalificacion.IdUsuario,
                        Puntaje = datoscalificacion.Puntaje
                    };

                    _unitOfWork.Calificaciones.Insert(cal);
                    _unitOfWork.Save();

                    return Ok("Califiacion ingresada");

                }
                return BadRequest("Modelo inválido");
            }
            catch (Exception)
            {
                return Ok("Error al ingresar la calificación");
            }
        }
        [HttpPut]
        public IActionResult UpdateCalificacion([FromBody] DatosCalificacion datoscalificacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Calificacion cal = new Calificacion()
                    {
                        Comentario = datoscalificacion.Comentario,
                        Fecha = datoscalificacion.Fecha,
                        IdRestaurant = datoscalificacion.IdRestaurant,
                        IdUsuario = datoscalificacion.IdUsuario,
                        Puntaje = datoscalificacion.Puntaje
                    };

                    _unitOfWork.Calificaciones.Update(cal);
                    _unitOfWork.Save();

                    return Ok("Califiacion ingresada");

                }
                return BadRequest("Modelo inválido");
            }
            catch (Exception)
            {
                return Ok("Error al ingresar la calificación");
            }
        }
    }
}
