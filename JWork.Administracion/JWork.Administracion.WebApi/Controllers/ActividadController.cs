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

        [HttpPost("Crear")]
        public async Task<ActionResult<Response<ActividadDto>>> Crear(Registrar.ActividadRegisterCommand actividadRegister)
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

        [HttpPut("Modificar")]
        public async Task<ActionResult<Response<ActividadDto>>> Modificar(Registrar.ActividadUpdateCommand command)
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

        // Eliminar api/<ActividadController>/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<Response<bool>>> Eliminar(int id)
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

        [HttpGet("GetTodo")]
        public async Task<ActionResult<Response<List<ActividadDto>>>> GetTodo()
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


        [HttpGet("GetPorId/{id}")]
        public async Task<ActionResult<Response<ActividadDto>>> GetPorId(int id)
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

        [HttpGet("Buscar")]
        public async Task<ActionResult<Response<List<ActividadDto>>>> Buscar(Buscar.ActividadBuscarCommand command)
        {
            Response<List<ActividadDto>> response = new();
            try
            {

                List<ActividadDto> actividadDtos = await _mediator.Send(command);

                response.Mensaje = "";
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



    }
}
