using JWork.Administracion.Business.Aplicacion.UnidadMedida;
using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JWork.Administracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadMedidaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UnidadMedidaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Response<UnidadMedidaDto>>> Post(Registrar.UnidadMedidaRegisterCommand UnidadMedidaRegister)
        {
            Response<UnidadMedidaDto> respon;
            try
            {
                UnidadMedidaDto UnidadMedida = await _mediator.Send(UnidadMedidaRegister);
                respon = new()
                {
                    Entidad = UnidadMedida,
                    Mensaje = "UnidadMedida creada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Response<UnidadMedidaDto>()
                {
                    Entidad = new UnidadMedidaDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }

        }

        [HttpPut]
        public async Task<ActionResult<Response<UnidadMedidaDto>>> Put(Registrar.UnidadMedidaUpdateCommand command)
        {
            Response<UnidadMedidaDto> respon;
            try
            {
                UnidadMedidaDto UnidadMedida = await _mediator.Send(command);
                respon = new()
                {
                    Entidad = UnidadMedida,
                    Mensaje = "UnidadMedida actualizada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Response<UnidadMedidaDto>()
                {
                    Entidad = new UnidadMedidaDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }
        }

        // DELETE api/<UnidadMedidaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
        {
            Response<bool> response = new();
            try
            {

                Registrar.UnidadMedidaEliminarCommand command = new()
                {
                    UnidadMedidaId = id
                };

                bool exitoso = await _mediator.Send(command);

                response.Mensaje = "UnidadMedida elimiminada correctamenta";
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
        public async Task<ActionResult<Response<List<UnidadMedidaDto>>>> Get()
        {
            Response<List<UnidadMedidaDto>> response = new();
            try
            {

                Buscar.UnidadMedidaBuscarTodoCommand command = new()
                {
                   
                };

                List<UnidadMedidaDto> UnidadMedidaDtos = await _mediator.Send(command);

                response.Mensaje = "UnidadMedida elimiminada correctamenta";
                response.Entidad = UnidadMedidaDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<UnidadMedidaDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response<UnidadMedidaDto>>> Get(int id)
        {
            Response<UnidadMedidaDto> response = new();
            try
            {

                Buscar.UnidadMedidaBuscarIdCommand command = new()
                {
                    UnidadMedidaId = id
                };

                UnidadMedidaDto UnidadMedidaDtos = await _mediator.Send(command);

                response.Mensaje = "UnidadMedida elimiminada correctamenta";
                response.Entidad = UnidadMedidaDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new UnidadMedidaDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<Response<UnidadMedidaDto>>> Get(Buscar.UnidadMedidaBuscarIdCommand command)
        {
            Response<UnidadMedidaDto> response = new();
            try
            {

                UnidadMedidaDto UnidadMedidaDtos = await _mediator.Send(command);

                response.Mensaje = "";
                response.Entidad = UnidadMedidaDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new UnidadMedidaDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }



    }
}
