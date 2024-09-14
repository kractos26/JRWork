using JWork.Administracion.Business.Aplicacion.TipoIdentificacion;
using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace JWork.Administracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIdentificacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TipoIdentificacionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Response<TipoIdentificacionDto>>> Crear(Registrar.TipoIdentificacionRegisterCommand TipoIdentificacionRegister)
        {
            Response<TipoIdentificacionDto> respon;
            try
            {
                TipoIdentificacionDto TipoIdentificacion = await _mediator.Send(TipoIdentificacionRegister);
                respon = new()
                {
                    Entidad = TipoIdentificacion,
                    Mensaje = "TipoIdentificacion creada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Response<TipoIdentificacionDto>()
                {
                    Entidad = new TipoIdentificacionDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }

        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<Response<TipoIdentificacionDto>>> Modificar(Registrar.TipoIdentificacionUpdateCommand command)
        {
            Response<TipoIdentificacionDto> respon;
            try
            {
                TipoIdentificacionDto TipoIdentificacion = await _mediator.Send(command);
                respon = new()
                {
                    Entidad = TipoIdentificacion,
                    Mensaje = "TipoIdentificacion actualizada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Response<TipoIdentificacionDto>()
                {
                    Entidad = new TipoIdentificacionDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }
        }

        // Eliminar api/<TipoIdentificacionController>/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<Response<bool>>> Eliminar(int id)
        {
            Response<bool> response = new();
            try
            {

                Registrar.TipoIdentificacionEliminarCommand command = new()
                {
                    TipoIdentificacionId = id
                };

                bool exitoso = await _mediator.Send(command);

                response.Mensaje = "TipoIdentificacion elimiminada correctamenta";
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
        public async Task<ActionResult<Response<List<TipoIdentificacionDto>>>> GetTodo()
        {
            Response<List<TipoIdentificacionDto>> response = new();
            try
            {

                Buscar.TipoIdentificacionBuscarTodoCommand command = new()
                {

                };

                List<TipoIdentificacionDto> TipoIdentificacionDtos = await _mediator.Send(command);

                response.Mensaje = "TipoIdentificacion elimiminada correctamenta";
                response.Entidad = TipoIdentificacionDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<TipoIdentificacionDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }


        [HttpGet("GetPorId/{id}")]
        public async Task<ActionResult<Response<TipoIdentificacionDto>>> GetPorId(int id)
        {
            Response<TipoIdentificacionDto> response = new();
            try
            {

                Buscar.TipoIdentificacionBuscarIdCommand command = new()
                {
                    TipoIdentificacionId = id
                };

                TipoIdentificacionDto TipoIdentificacionDtos = await _mediator.Send(command);

                response.Mensaje = "TipoIdentificacion elimiminada correctamenta";
                response.Entidad = TipoIdentificacionDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new TipoIdentificacionDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<Response<List<TipoIdentificacionDto>>>> Buscar(Buscar.TipoIdentificacionBuscarCommand command)
        {
            Response<List<TipoIdentificacionDto>> response = new();
            try
            {

                List<TipoIdentificacionDto> TipoIdentificacionDtos = await _mediator.Send(command);

                response.Mensaje = "";
                response.Entidad = TipoIdentificacionDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<TipoIdentificacionDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }
    }
}
