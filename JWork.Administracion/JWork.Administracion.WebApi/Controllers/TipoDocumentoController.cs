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
        // GET: TipoDocumentoController
        [HttpPost]
        public async Task<ActionResult<Response<TipoDocumentoDto>>> Post(Registrar.TipoDocumentoRegisterCommand tipodocRegister)
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

        [HttpPut]
        public async Task<ActionResult<Response<TipoDocumentoDto>>> Put(Registrar.TipoDocumentoUpdateCommand command)
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

        // DELETE api/<TipoDocumentoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
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

        [HttpGet]
        public async Task<ActionResult<Response<List<TipoDocumentoDto>>>> Get()
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


        [HttpGet("{id}")]
        public async Task<ActionResult<Response<TipoDocumentoDto>>> Get(int id)
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

        [HttpGet("search")]
        public async Task<ActionResult<Response<TipoDocumentoDto>>> Get(Buscar.TipoDocumentoBuscarIdCommand command)
        {
            Response<TipoDocumentoDto> response = new();
            try
            {

                TipoDocumentoDto TipoDocumentoDtos = await _mediator.Send(command);

                response.Mensaje = "";
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
    }
}
