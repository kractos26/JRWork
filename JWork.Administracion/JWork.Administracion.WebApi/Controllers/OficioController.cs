using JWork.Administracion.Business.Aplicacion.Oficio;
using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWork.Administracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OficioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OficioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<OficioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OficioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OficioController>
        [HttpPost]
        public async Task<ActionResult<Response<OficioDto>>> Post(Registrar.OficioRegisterCommand oficioRegister)
        {
            Response<OficioDto> respon;
            try
            {
                OficioDto area = await _mediator.Send(oficioRegister);
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
                respon = new Response<OficioDto>()
                {
                    Entidad = new OficioDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }

        }

        [HttpPut]
        public async Task<ActionResult<Response<OficioDto>>> Put(Registrar.OficioUpdateCommand command)
        {
            Response<OficioDto> respon;
            try
            {
                OficioDto Oficio = await _mediator.Send(command);
                respon = new()
                {
                    Entidad = Oficio,
                    Mensaje = "Oficio actualizada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Response<OficioDto>()
                {
                    Entidad = new OficioDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }
        }

        // DELETE api/<OficioController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
        {
            Response<bool> response = new();
            try
            {

                Registrar.OficioEliminarCommand command = new()
                {
                    OficioId = id
                };

                bool exitoso = await _mediator.Send(command);

                response.Mensaje = "Oficio elimiminada correctamenta";
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
