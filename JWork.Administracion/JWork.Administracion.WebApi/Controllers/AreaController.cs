using JWork.Administracion.Business.Aplicacion.Area;
using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWork.Administracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AreaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<AreaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AreaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value"+id;
        }

        // POST api/<AreaController>
        [HttpPost]
        public async Task<ActionResult<Response<AreaDto>>> Post(Registrar.AreaRegisterCommand areaRegister)
        {
            Response<AreaDto> respon;
            try
            {
                AreaDto area = await _mediator.Send(areaRegister);
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
                respon = new Models.Response<AreaDto>()
                {
                    Entidad = new AreaDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }

        }
        // PUT api/<AreaController>/5
        [HttpPut]
        public async Task<ActionResult<Response<AreaDto>>> Put(Registrar.AreaUpdateCommand command)
        {
            Response<AreaDto> respon;
            try
            {
                AreaDto area = await _mediator.Send(command);
                respon = new()
                {
                    Entidad = area,
                    Mensaje = "Area actualizada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Models.Response<AreaDto>()
                {
                    Entidad = new AreaDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }
        }

        // DELETE api/<AreaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
        {
            Response<bool> response = new();
            try
            {
               
                Registrar.AreaEliminarCommand command = new Registrar.AreaEliminarCommand()
                {
                    AreaId = id
                };

                bool exitoso = await _mediator.Send(command);

                response.Mensaje = "Area elimiminada correctamenta";
                response.Entidad = exitoso;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new ()
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
