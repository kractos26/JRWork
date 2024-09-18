using JWork.Administracion.Business.Aplicacion.Area;
using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWork.Administracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AreaController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // Crear api/<AreaController>
        [HttpPost("Crear")]
        public async Task<ActionResult<Response<AreaDto>>> Crear(Registrar.AreaRegisterCommand areaRegister)
        {
            Response<AreaDto> respon;
            try
            {
                AreaDto area = await _mediator.Send(areaRegister);
                respon = new()
                {
                    Entidad = area,
                    Mensaje = "Area creada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Response<AreaDto>()
                {
                    Entidad = new AreaDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }

        }
        // Modificar api/<AreaController>/5
        [HttpPut("Modificar")]
        public async Task<ActionResult<Response<AreaDto>>> Modificar(Registrar.AreaUpdateCommand command)
        {
            Response<AreaDto> respon;
            try
            {
                AreaDto area = await _mediator.Send(command);
                respon = new()
                {
                    Entidad = area,
                    Mensaje = "Area actualizada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Models.Response<AreaDto>()
                {
                    Entidad = new AreaDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }
        }

        // Eliminar api/<AreaController>/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<Response<bool>>> Eliminar(int id)
        {
            Response<bool> response = new();
            try
            {

                Registrar.AreaEliminarCommand command = new()
                {
                    AreaId = id
                };

                bool exitoso = await _mediator.Send(command);

                response.Mensaje = "Area elimiminada correctamenta";
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
        public async Task<ActionResult<Response<List<AreaDto>>>> GetTodo()
        {
            Response<List<AreaDto>> response = new();
            try
            {

                Buscar.AreaBuscarTodoCommand command = new()
                {

                };

                List<AreaDto> AreaDtos = await _mediator.Send(command);

                response.Mensaje = "Area elimiminada correctamenta";
                response.Entidad = AreaDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<AreaDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }


        [HttpGet("GetPorId/{id}")]
        public async Task<ActionResult<Response<AreaDto>>> GetPorId(int id)
        {
            Response<AreaDto> response = new();
            try
            {

                Buscar.AreaBuscarIdCommand command = new()
                {
                    AreaId = id
                };

                AreaDto AreaDtos = await _mediator.Send(command);

                response.Mensaje = "Area elimiminada correctamenta";
                response.Entidad = AreaDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new AreaDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<Response<List<AreaDto>>>> Buscar(Buscar.AreaBuscarCommand command)
        {
            Response<List<AreaDto>> response = new();
            try
            {

                List<AreaDto> AreaDtos = await _mediator.Send(command);

                response.Mensaje = "";
                response.Entidad = AreaDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<AreaDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }

        [HttpGet("BuscarPaginado")]
        public async Task<ActionResult<Response<List<ActividadDto>>>> BuscarPaginado([FromQuery] Buscar.AreaBuscarPaginadoCommand command)
        {
            try
            {
                List<AreaDto> actividadDtos = await _mediator.Send(command);

                var response = new Response<List<AreaDto>>
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
