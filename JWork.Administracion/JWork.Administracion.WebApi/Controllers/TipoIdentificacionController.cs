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

        [HttpPost]
        public async Task<ActionResult<Response<TipoIdentificacionDto>>> Post(Registrar.TipoIdentificacionRegisterCommand TipoIdentificacionRegister)
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

        [HttpPut]
        public async Task<ActionResult<Response<TipoIdentificacionDto>>> Put(Registrar.TipoIdentificacionUpdateCommand command)
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

        // DELETE api/<TipoIdentificacionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
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

        [HttpGet]
        public async Task<ActionResult<Response<List<TipoIdentificacionDto>>>> Get()
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


        [HttpGet("{id}")]
        public async Task<ActionResult<Response<TipoIdentificacionDto>>> Get(int id)
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

        [HttpGet("search")]
        public async Task<ActionResult<Response<TipoIdentificacionDto>>> Get(Buscar.TipoIdentificacionBuscarIdCommand command)
        {
            Response<TipoIdentificacionDto> response = new();
            try
            {

                TipoIdentificacionDto TipoIdentificacionDtos = await _mediator.Send(command);

                response.Mensaje = "";
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
    }
}
