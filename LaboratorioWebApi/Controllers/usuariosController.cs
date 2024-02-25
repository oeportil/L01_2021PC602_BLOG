using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaboratorioWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private readonly Contexto _contexto;

        public usuariosController(Contexto contexto) {

            _contexto = contexto;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Usuarios> listadoUsuarios = (from e in _contexto.Usuarios
                                              select e).ToList();

            if (listadoUsuarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoUsuarios);
        }
        [HttpGet]
        [Route("FnombreApellido")]
        public IActionResult BuscarPorNombreApellido(string nombre, string apellido)
        {
            var usuariosFiltrados = _contexto.Usuarios
                                    .Where(u => u.Nombre.Contains(nombre) && u.Apellido.Contains(apellido))
                                    .ToList();

            if (usuariosFiltrados.Count == 0)
            {
                return NotFound("No se encontraron usuarios con el nombre y apellido ingresados");
            }

            return Ok(usuariosFiltrados);
        }


        [HttpGet]
        [Route("FRol")]
        public IActionResult BuscarPorRol(int rolId)
        {
            var usuariosFiltrados = _contexto.Usuarios
                .Where(u => u.RolId == rolId)
                .ToList();

            if (usuariosFiltrados.Count == 0)
            {
                return NotFound("No se encontraron usuarios con el rol ingresado");
            }

            return Ok(usuariosFiltrados);
        }



        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarUsuario([FromBody] Usuarios usuario)
        {
            try
            {
                _contexto.Usuarios.Add(usuario);
                _contexto.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Actualizar/{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] Usuarios usuarioActualizado)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound($"Usuario con ID {id} no encontrado");
            }

            usuario.RolId = usuarioActualizado.RolId;
            usuario.NombreUsuario = usuarioActualizado.NombreUsuario;
            usuario.Clave = usuarioActualizado.Clave;
            usuario.Nombre = usuarioActualizado.Nombre;
            usuario.Apellido = usuarioActualizado.Apellido;

            _contexto.SaveChanges();

            return Ok($"Usuario con ID {id} actualizado exitosamente");
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound($"Usuario con ID {id} no encontrado");
            }

            _contexto.Usuarios.Remove(usuario);
            _contexto.SaveChanges();

            return Ok($"Usuario con ID {id} eliminado exitosamente");
        }


    }
}
