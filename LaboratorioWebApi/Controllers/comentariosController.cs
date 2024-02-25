using LaboratorioWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class comentariosController : ControllerBase
    {
        private readonly Contexto _contexto;

        public comentariosController(Contexto contexto)
        {

            _contexto = contexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Comentarios> listadoComentarios = (from e in _contexto.Comentarios
                                                    select e).ToList();
            if (listadoComentarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoComentarios);
        }

        [HttpPost]
        [Route("Agregar")]

        public IActionResult PostComentarios([FromBody] Comentarios comentario)
        {
            try
            {
                _contexto.Comentarios.Add(comentario);
                _contexto.SaveChanges();

                return Ok("Comentario agregado exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Actualizar/{id}")]
        public IActionResult ActualizarComentario(int id, [FromBody] Comentarios comentarioActualizado)
        {
            var comentario = _contexto.Comentarios.FirstOrDefault(c => c.CometarioId == id);
            if (comentario == null)
            {
                return NotFound($"Comentario con ID {id} no encontrado");
            }

            comentario.PublicacionId = comentarioActualizado.PublicacionId;
            comentario.UsuarioId = comentarioActualizado.UsuarioId;
            comentario.Comentario1 = comentarioActualizado.Comentario1;

            _contexto.SaveChanges();

            return Ok($"Comentario con ID {id} actualizado exitosamente");
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarComentario(int id)
        {
            var comentario = _contexto.Comentarios.FirstOrDefault(c => c.CometarioId == id);
            if (comentario == null)
            {
                return NotFound($"Comentarios con ID {id} no encontrada");
            }

            _contexto.Comentarios.Remove(comentario);
            _contexto.SaveChanges();

            return Ok($"Comentarios con ID {id} eliminada exitosamente");
        }

        [HttpGet]
        [Route("ComentariosPorPublicacion/{publicacionId}")]
        public IActionResult ComentariosPorUsuario(int publicacionId)
        {
            var comentarios = _contexto.Comentarios.Where(c => c.PublicacionId == publicacionId).ToList();
            if (comentarios.Count == 0)
            {
                return NotFound($"No se encontraron comentarios en la publicacion con ID {publicacionId}");
            }

            return Ok(comentarios);
        }
    }
}
