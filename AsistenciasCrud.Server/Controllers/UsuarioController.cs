using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AsistenciasCrud.Server.Models;
using AsistenciasCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace AsistenciasCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly RegistroasistenciaContext _dbContext;

        public UsuarioController(RegistroasistenciaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Mostrar")]

        public async Task<IActionResult> Mostrar()
        {
            var responseApi = new ResponseAPI<List<Usuario>>();
            var listaUsuario = new List<Usuario>();

            try
            {
                foreach(var item in await _dbContext.Usuarios.ToListAsync())
                {
                    listaUsuario.Add(new Usuario
                    {
                       IdUsuario = item.IdUsuario,
                       Nombre = item.Nombre,
                       ApellidoP = item.ApellidoP,
                       ApellidoM = item.ApellidoM,
                       Correo = item.Correo,
                       Telefono = item.Telefono,
                    });
                }

                responseApi.Correcto = true;
                responseApi.Valor = listaUsuario;

            }
            catch (Exception ex)
            {
                responseApi.Correcto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }
    }
}
