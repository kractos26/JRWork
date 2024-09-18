using JWork.Administracion.Business.Aplicacion.TipoDocumento;
using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWork.Administracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TipoDocumentoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // get: TipoDocumentoController
        [HttpPost("Crear")]
        public async Task<ActionResult<Response<TipoDocumentoDto>>> Crear(Registrar.TipoDocumentoRegisterCommand tipodocRegister)
        {
            Response<TipoDocumentoDto> respon;
            try
            {
                TipoDocumentoDto area = await _mediator.Send(tipodocRegister);
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
                respon = new Response<TipoDocumentoDto>()
                {
                    Entidad = new TipoDocumentoDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }

        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<Response<TipoDocumentoDto>>> Modificar(Registrar.TipoDocumentoUpdateCommand command)
        {
            Response<TipoDocumentoDto> respon;
            try
            {
                TipoDocumentoDto TipoDocumento = await _mediator.Send(command);
                respon = new()
                {
                    Entidad = TipoDocumento,
                    Mensaje = "TipoDocumento actualizada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Response<TipoDocumentoDto>()
                {
                    Entidad = new TipoDocumentoDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }
        }

        // Eliminar api/<TipoDocumentoController>/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<Response<bool>>> Eliminar(int id)
        {
            Response<bool> response = new();
            try
            {
                Registrar.TipoDocumentoEliminarCommand command = new()
                {
                    TipoDocumentoId = id
                };

                bool exitoso = await _mediator.Send(command);

                response.Mensaje = "TipoDocumento elimiminada correctamenta";
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
        public async Task<ActionResult<Response<List<TipoDocumentoDto>>>> GetTodo()
        {
            Response<List<TipoDocumentoDto>> response = new();
            try
            {

                Buscar.TipoDocumentoBuscarTodoCommand command = new()
                {

                };

                List<TipoDocumentoDto> TipoDocumentoDtos = await _mediator.Send(command);

                response.Mensaje = "TipoDocumento elimiminada correctamenta";
                response.Entidad = TipoDocumentoDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<TipoDocumentoDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }


        [HttpGet("GetPorId/{id}")]
        public async Task<ActionResult<Response<TipoDocumentoDto>>> GetPorId(int id)
        {
            Response<TipoDocumentoDto> response = new();
            try
            {

                Buscar.TipoDocumentoBuscarIdCommand command = new()
                {
                    TipoDocumentoId = id
                };

                TipoDocumentoDto TipoDocumentoDtos = await _mediator.Send(command);

                response.Mensaje = "TipoDocumento elimiminada correctamenta";
                response.Entidad = TipoDocumentoDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new TipoDocumentoDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<Response<List<TipoDocumentoDto>>>> Buscar(Buscar.TipoDocumentoBuscarCommand command)
        {
            Response<List<TipoDocumentoDto>> response = new();
            try
            {

                List<TipoDocumentoDto> TipoDocumentoDtos = await _mediator.Send(command);

                response.Mensaje = "";
                response.Entidad = TipoDocumentoDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<TipoDocumentoDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }

        [HttpGet("BuscarPaginado")]
        public async Task<ActionResult<Response<List<TipoDocumentoDto>>>> BuscarPaginado([FromQuery] Buscar.TipoDocumentoBuscarPaginadoCommand command)
        {
            try
            {
                List<TipoDocumentoDto> actividadDtos = await _mediator.Send(command);

                var response = new Response<List<TipoDocumentoDto>>
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
