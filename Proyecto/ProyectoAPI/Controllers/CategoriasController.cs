using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Data;
using ProyectoAPI.Entities.Models;
using ProyectoAPI.Services;

namespace ProyectoAPI.Controllers
{
    [Route("api/v1/XamarinCurso/[Controller]")]
    public class CategoriasController : Controller
    {
        private dbaplicationContext _context = new dbaplicationContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new dbaplicationContext());

        [HttpGet]
        public IActionResult GetAllCategoria()
        {
            var categorias= _unitOfWork.Categorias.Get();
            if (categorias != null)
            {
                var res = Newtonsoft.Json.JsonConvert.SerializeObject(categorias);
                return Ok(res);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            Categoria categoria = _unitOfWork.Categorias.GetById(id);
            if (categoria!= null)
            {
                return Ok(categoria);
            }
            else
            {
                return BadRequest("No se encuentra el registro");
            }
        }

        [HttpPut]
        public IActionResult UpdateCategoria([FromBody] Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Categorias.Update(categoria);
                    _unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteCategoria(int id)
        {
            if (id != 0)
            {
                _unitOfWork.Categorias.Delete(id);
                _unitOfWork.Save();
                return Ok("Categoria eliminado");
            }
            else 
            {
                return BadRequest("Categoria con Id es invalido");
            }
        }
    }
}
