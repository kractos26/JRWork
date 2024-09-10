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
                ConceptoCalificacionDto ConceptoCalificacion = await _mediator.Send(conRegister);
                respon = new()
                {
                    Entidad = ConceptoCalificacion,
                    Mensaje = "ConceptoCalificacion creada correctamente",
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

        [HttpPut]
        public async Task<ActionResult<Response<ConceptoCalificacionDto>>> Put(Registrar.ConceptoCalificacionUpdateCommand command)
        {
            Response<ConceptoCalificacionDto> respon;
            try
            {
                ConceptoCalificacionDto ConceptoCalificacion = await _mediator.Send(command);
                respon = new()
                {
                    Entidad = ConceptoCalificacion,
                    Mensaje = "ConceptoCalificacion actualizada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Models.Response<ConceptoCalificacionDto>()
                {
                    Entidad = new ConceptoCalificacionDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }
        }

        // DELETE api/<ConceptoCalificacionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
        {
            Response<bool> response = new();
            try
            {

                Registrar.ConceptoCalificacionEliminarCommand command = new()
                {
                    ConceptoCalificacionId = id
                };

                bool exitoso = await _mediator.Send(command);

                response.Mensaje = "ConceptoCalificacion elimiminada correctamenta";
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
    }
}
