using JWork.Administracion.Business.Aplicacion.Actividad;
using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JWork.Administracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ActividadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Response<ActividadDto>>> Post(Registar.ActividadRegisterCommand actividadRegister)
        {
            Response<ActividadDto> respon;
            try
            {
                ActividadDto Actividad = await _mediator.Send(actividadRegister);
                respon = new()
                {
                    Entidad = Actividad,
                    Mensaje = "Actividad creada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Response<ActividadDto>()
                {
                    Entidad = new ActividadDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }

        }

        [HttpPut]
        public async Task<ActionResult<Response<ActividadDto>>> Put(Registar.ActividadUpdateCommand command)
        {
            Response<ActividadDto> respon;
            try
            {
                ActividadDto Actividad = await _mediator.Send(command);
                respon = new()
                {
                    Entidad = Actividad,
                    Mensaje = "Actividad actualizada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Models.Response<ActividadDto>()
                {
                    Entidad = new ActividadDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }
        }

        // DELETE api/<ActividadController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
        {
            Response<bool> response = new();
            try
            {

                Registar.ActividadEliminarCommand command = new Registar.ActividadEliminarCommand()
                {
                    ActividadId = id
                };

                bool exitoso = await _mediator.Send(command);

                response.Mensaje = "Actividad elimiminada correctamenta";
                response.Entidad = exitoso;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = false,
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }
    }
}
