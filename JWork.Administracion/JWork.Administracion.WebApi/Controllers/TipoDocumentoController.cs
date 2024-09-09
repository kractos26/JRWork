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

    }
}
