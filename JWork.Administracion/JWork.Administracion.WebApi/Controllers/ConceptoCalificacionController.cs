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

        [HttpPost("Crear")]
        public async Task<ActionResult<Response<ConceptoCalificacionDto>>> Crear(Registrar.ConceptoCalificacionRegisterCommand conRegister)
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

        [HttpPut("Modificar")]
        public async Task<ActionResult<Response<ConceptoCalificacionDto>>> Modificar(Registrar.ConceptoCalificacionUpdateCommand command)
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

        // Eliminar api/<ConceptoCalificacionController>/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<Response<bool>>> Eliminar(int id)
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

        [HttpGet("GetTodo")]
        public async Task<ActionResult<Response<List<ConceptoCalificacionDto>>>> GetTodo()
        {
            Response<List<ConceptoCalificacionDto>> response = new();
            try
            {

                Buscar.ConceptoCalificacionBuscarTodoCommand command = new()
                {

                };

                List<ConceptoCalificacionDto> ConceptoCalificacionDtos = await _mediator.Send(command);

                response.Mensaje = "ConceptoCalificacion elimiminada correctamenta";
                response.Entidad = ConceptoCalificacionDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<ConceptoCalificacionDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }


        [HttpGet("GetPorId/{id}")]
        public async Task<ActionResult<Response<ConceptoCalificacionDto>>> GetPorId(int id)
        {
            Response<ConceptoCalificacionDto> response = new();
            try
            {

                Buscar.ConceptoCalificacionBuscarIdCommand command = new()
                {
                    ConceptoCalificacionId = id
                };

                ConceptoCalificacionDto ConceptoCalificacionDtos = await _mediator.Send(command);

                response.Mensaje = "ConceptoCalificacion elimiminada correctamenta";
                response.Entidad = ConceptoCalificacionDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new ConceptoCalificacionDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<Response<List<List<ConceptoCalificacionDto>>>>> Buscar(Buscar.ConceptoCalificacionBuscarCommand command)
        {
            Response<List<ConceptoCalificacionDto>> response = new();
            try
            {

                List<ConceptoCalificacionDto> ConceptoCalificacionDtos = await _mediator.Send(command);

                response.Mensaje = "";
                response.Entidad = ConceptoCalificacionDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<ConceptoCalificacionDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }
    }
}
