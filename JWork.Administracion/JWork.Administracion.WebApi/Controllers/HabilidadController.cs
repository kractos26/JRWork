using JWork.Administracion.Business.Aplicacion.Habilidad;
using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWork.Administracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HabilidadController(IMediator mediator)
        {
            _mediator = mediator;
        }
    

        [HttpPost]
        public async Task<ActionResult<Response<HabilidadDto>>> Post(Registrar.HabilidadRegisterCommand habilidadRegister)
        {
            Response<Dto.HabilidadDto> respon;
            try
            {
                Dto.HabilidadDto area = await _mediator.Send(habilidadRegister);
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
                respon = new Response<Dto.HabilidadDto>()
                {
                    Entidad = new Dto.HabilidadDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }

        }


        [HttpPut]
        public async Task<ActionResult<Response<HabilidadDto>>> Put(Registrar.HabilidadUpdateCommand command)
        {
            Response<HabilidadDto> respon;
            try
            {
                HabilidadDto Habilidad = await _mediator.Send(command);
                respon = new()
                {
                    Entidad = Habilidad,
                    Mensaje = "Habilidad actualizada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Response<HabilidadDto>()
                {
                    Entidad = new HabilidadDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }
        }

        // DELETE api/<HabilidadController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
        {
            Response<bool> response = new();
            try
            {

                Registrar.HabilidadEliminarCommand command = new()
                {
                    HabilidadId = id
                };

                bool exitoso = await _mediator.Send(command);

                response.Mensaje = "Habilidad elimiminada correctamenta";
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
        public async Task<ActionResult<Response<List<HabilidadDto>>>> Get()
        {
            Response<List<HabilidadDto>> response = new();
            try
            {

                Buscar.HabilidadBuscarTodoCommand command = new()
                {

                };

                List<HabilidadDto> HabilidadDtos = await _mediator.Send(command);

                response.Mensaje = "Habilidad elimiminada correctamenta";
                response.Entidad = HabilidadDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<HabilidadDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response<HabilidadDto>>> Get(int id)
        {
            Response<HabilidadDto> response = new();
            try
            {

                Buscar.HabilidadBuscarIdCommand command = new()
                {
                    HabilidadId = id
                };

                HabilidadDto HabilidadDtos = await _mediator.Send(command);

                response.Mensaje = "Habilidad elimiminada correctamenta";
                response.Entidad = HabilidadDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new HabilidadDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<Response<HabilidadDto>>> Get(Buscar.HabilidadBuscarIdCommand command)
        {
            Response<HabilidadDto> response = new();
            try
            {

                HabilidadDto HabilidadDtos = await _mediator.Send(command);

                response.Mensaje = "";
                response.Entidad = HabilidadDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new HabilidadDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }
    }
}
