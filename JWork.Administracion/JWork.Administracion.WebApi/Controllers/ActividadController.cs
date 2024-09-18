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
            try
            {
                ActividadDto actividad = await _mediator.Send(actividadRegister);
                var respon = new Response<ActividadDto>
                {
                    Entidad = actividad,
                    Mensaje = "Actividad creada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                var respon = new Response<ActividadDto>
                {
                    Entidad = new ActividadDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest
                };
                return BadRequest(respon);
            }
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<Response<ActividadDto>>> Modificar(Registrar.ActividadUpdateCommand command)
        {
            try
            {
                ActividadDto actividad = await _mediator.Send(command);
                var respon = new Response<ActividadDto>
                {
                    Entidad = actividad,
                    Mensaje = "Actividad actualizada correctamente",
                    Status = System.Net.HttpStatusCode.OK
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                var respon = new Response<ActividadDto>
                {
                    Entidad = new ActividadDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest
                };
                return BadRequest(respon);
            }
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<Response<bool>>> Eliminar(int id)
        {
            try
            {
                var command = new Registrar.ActividadEliminarCommand
                {
                    ActividadId = id
                };

                bool exitoso = await _mediator.Send(command);

                var response = new Response<bool>
                {
                    Mensaje = "Actividad eliminada correctamente",
                    Entidad = exitoso,
                    Status = System.Net.HttpStatusCode.OK
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new Response<bool>
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
            try
            {
                var command = new Buscar.ActividadBuscarTodoCommand();

                List<ActividadDto> actividadDtos = await _mediator.Send(command);

                var response = new Response<List<ActividadDto>>
                {
                    Mensaje = "Actividades obtenidas correctamente",
                    Entidad = actividadDtos,
                    Status = System.Net.HttpStatusCode.OK
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new Response<List<ActividadDto>>
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
            try
            {
                var command = new Buscar.ActividadBuscarIdCommand
                {
                    ActividadId = id
                };

                ActividadDto actividadDto = await _mediator.Send(command);

                var response = new Response<ActividadDto>
                {
                    Mensaje = "Actividad obtenida correctamente",
                    Entidad = actividadDto,
                    Status = System.Net.HttpStatusCode.OK
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new Response<ActividadDto>
                {
                    Entidad = new ActividadDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest
                };
                return BadRequest(response);
            }
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<Response<List<ActividadDto>>>> Buscar([FromQuery] Buscar.ActividadBuscarCommand command)
        {
            try
            {
                List<ActividadDto> actividadDtos = await _mediator.Send(command);

                var response = new Response<List<ActividadDto>>
                {
                    Mensaje = "Actividades encontradas correctamente",
                    Entidad = actividadDtos,
                    Status = System.Net.HttpStatusCode.OK
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new Response<List<ActividadDto>>
                {
                    Entidad = new List<ActividadDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest
                };
                return BadRequest(response);
            }
        }

        [HttpGet("BuscarPaginado")]
        public async Task<ActionResult<Response<List<ActividadDto>>>> BuscarPaginado([FromQuery] Buscar.ActividadBuscarPaginadoCommand command)
        {
            try
            {
                List<ActividadDto> actividadDtos = await _mediator.Send(command);

                var response = new Response<List<ActividadDto>>
                {
                    Mensaje = "Actividades encontradas correctamente",
                    Entidad = actividadDtos,
                    Status = System.Net.HttpStatusCode.OK
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new Response<List<ActividadDto>>
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
