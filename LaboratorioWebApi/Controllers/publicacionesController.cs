using LaboratorioWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class publicacionesController : ControllerBase
    {
        private readonly Contexto _contexto;

        public publicacionesController(Contexto contexto)
        {

            _contexto = contexto;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Publicaciones> listadoPublicaciones = (from e in _contexto.Publicaciones
                                                    select e).ToList();
            if (listadoPublicaciones.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoPublicaciones);
        }

        [HttpPost]
        [Route("Agregar")]

        public IActionResult PostPublicacion([FromBody] Publicaciones publicacion)
        {
            try
            {
                _contexto.Publicaciones.Add(publicacion);
                _contexto.SaveChanges();

                return Ok("Publicacion agregado exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Actualizar/{id}")]
        public IActionResult ActualizarPublicacion(int id, [FromBody] Publicaciones publicacionActualizado)
        {
            var publicacion = _contexto.Publicaciones.FirstOrDefault(p => p.PublicacionId == id);
            if (publicacion == null)
            {
                return NotFound($"Publicacion con ID {id} no encontrado");
            }

            publicacion.PublicacionId = publicacionActualizado.PublicacionId;
            publicacion.UsuarioId = publicacionActualizado.UsuarioId;
            publicacion.Titulo = publicacionActualizado.Titulo;
            publicacion.Descripcion = publicacionActualizado.Descripcion;

            _contexto.SaveChanges();

            return Ok($"Publicacion con ID {id} actualizado exitosamente");
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarPublicacion(int id)
        {
            var publicacion = _contexto.Publicaciones.FirstOrDefault(p => p.PublicacionId == id);
            if (publicacion == null)
            {
                return NotFound($"Publicacion con ID {id} no encontrada");
            }

            _contexto.Publicaciones.Remove(publicacion);
            _contexto.SaveChanges();

            return Ok($"Publicacion con ID {id} eliminada exitosamente");
        }

        [HttpGet]
        [Route("PublicacionPorUsuario/{usuarioId}")]
        public IActionResult ComentariosPorUsuario(int usuarioId)
        {
            var publicacion = _contexto.Publicaciones.Where(p => p.UsuarioId == usuarioId).ToList();
            if (publicacion.Count == 0)
            {
                return NotFound($"No se encontro la publicacion por usuario con ID {usuarioId}");
            }

            return Ok(publicacion);
        }
    }
}
