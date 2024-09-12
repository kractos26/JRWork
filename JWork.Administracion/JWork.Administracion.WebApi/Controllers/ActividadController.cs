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
        public async Task<ActionResult<Response<ActividadDto>>> Post(Registrar.ActividadRegisterCommand actividadRegister)
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
        public async Task<ActionResult<Response<ActividadDto>>> Put(Registrar.ActividadUpdateCommand command)
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
                respon = new Response<ActividadDto>()
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

                Registrar.ActividadEliminarCommand command = new()
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

        [HttpGet]
        public async Task<ActionResult<Response<List<ActividadDto>>>> Get()
        {
            Response<List<ActividadDto>> response = new();
            try
            {

                Buscar.ActividadBuscarTodoCommand command = new()
                {
                   
                };

                List<ActividadDto> actividadDtos = await _mediator.Send(command);

                response.Mensaje = "Actividad elimiminada correctamenta";
                response.Entidad = actividadDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<ActividadDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response<ActividadDto>>> Get(int id)
        {
            Response<ActividadDto> response = new();
            try
            {

                Buscar.ActividadBuscarIdCommand command = new()
                {
                    ActividadId = id
                };

                ActividadDto actividadDtos = await _mediator.Send(command);

                response.Mensaje = "Actividad elimiminada correctamenta";
                response.Entidad = actividadDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new ActividadDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<Response<ActividadDto>>> Get(Buscar.ActividadBuscarIdCommand command)
        {
            Response<ActividadDto> response = new();
            try
            {

                ActividadDto actividadDtos = await _mediator.Send(command);

                response.Mensaje = "";
                response.Entidad = actividadDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new ActividadDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }



    }
}
