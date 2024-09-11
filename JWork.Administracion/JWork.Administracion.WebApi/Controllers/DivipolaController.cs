using JWork.Administracion.Business.Aplicacion.Divipola;
using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace JWork.Administracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivipolaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DivipolaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Response<DivipolaDto>>> Post(Registrar.DivipolaRegisterCommand DivipolaRegister)
        {
            Response<DivipolaDto> respon;
            try
            {
                DivipolaDto Divipola = await _mediator.Send(DivipolaRegister);
                respon = new()
                {
                    Entidad = Divipola,
                    Mensaje = "Divipola creada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Response<DivipolaDto>()
                {
                    Entidad = new DivipolaDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }

        }

        [HttpPut]
        public async Task<ActionResult<Response<DivipolaDto>>> Put(Registrar.DivipolaUpdateCommand command)
        {
            Response<DivipolaDto> respon;
            try
            {
                DivipolaDto Divipola = await _mediator.Send(command);
                respon = new()
                {
                    Entidad = Divipola,
                    Mensaje = "Divipola actualizada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Response<DivipolaDto>()
                {
                    Entidad = new DivipolaDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }
        }

        // DELETE api/<DivipolaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
        {
            Response<bool> response = new();
            try
            {

                Registrar.DivipolaEliminarCommand command = new Registrar.DivipolaEliminarCommand()
                {
                    DivipolaId = id
                };

                bool exitoso = await _mediator.Send(command);

                response.Mensaje = "Divipola elimiminada correctamenta";
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
