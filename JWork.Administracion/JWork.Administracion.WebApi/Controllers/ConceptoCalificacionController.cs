using JWork.Administracion.Business.Aplicacion.ConceptoCalificacion;
using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JWork.Administracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptoCalificacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConceptoCalificacionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Response<ConceptoCalificacionDto>>> Post(Registrar.ConceptoCalificacionRegisterCommand conRegister)
        {
            Response<ConceptoCalificacionDto> respon;
            try
            {
                ConceptoCalificacionDto area = await _mediator.Send(conRegister);
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
                respon = new Response<ConceptoCalificacionDto>()
                {
                    Entidad = new ConceptoCalificacionDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }

        }
    }
}
