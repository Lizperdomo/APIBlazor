using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AsistenciasCrud.Server.Models;
using AsistenciasCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace AsistenciasCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciaController : ControllerBase
    {
        private readonly RegistroasistenciaContext _dbContext;

        public AsistenciaController(RegistroasistenciaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Mostrar")]

        public async Task<IActionResult> Mostrar()
        {
            var responseApi = new ResponseAPI<List<Asistencia>>();
            var listaAsistencia = new List<Asistencia>();

            try
            {
                foreach (var item in await _dbContext.Asistencias.Include(u => u.IdUsuarioNavigation).ToListAsync())
                {
                    listaAsistencia.Add(new Asistencia
                    {
                         IdAsistencia = item.IdAsistencia,
                         IdUsuario = item.IdUsuario,
                         HoraEntrada = item.HoraEntrada,
                         HoraSalida = item.HoraSalida,
                         Fecha = item.Fecha,
                         Usuarios = new Usuario{
                             IdUsuario = item.IdUsuarioNavigation.IdUsuario,
                             Nombre = item.IdUsuarioNavigation.Nombre,
                         }
                    });
                }

                responseApi.Correcto = true;
                responseApi.Valor = listaAsistencia;

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
