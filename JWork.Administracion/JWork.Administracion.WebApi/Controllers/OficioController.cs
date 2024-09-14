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
        // get: api/<OficioController>
      
        [HttpPost("Crear")]
        public async Task<ActionResult<Response<OficioDto>>> Crear(Registrar.OficioRegisterCommand oficioRegister)
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

        [HttpPut("Modificar")]
        public async Task<ActionResult<Response<OficioDto>>> Modificar(Registrar.OficioUpdateCommand command)
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

        // Eliminar api/<OficioController>/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<Response<bool>>> Eliminar(int id)
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

        [HttpGet("GetTodo")]
        public async Task<ActionResult<Response<List<OficioDto>>>> GetTodo()
        {
            Response<List<OficioDto>> response = new();
            try
            {

                Buscar.OficioBuscarTodoCommand command = new()
                {

                };

                List<OficioDto> OficioDtos = await _mediator.Send(command);

                response.Mensaje = "Oficio elimiminada correctamenta";
                response.Entidad = OficioDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<OficioDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }


        [HttpGet("GetPorId/{id}")]
        public async Task<ActionResult<Response<OficioDto>>> GetPorId(int id)
        {
            Response<OficioDto> response = new();
            try
            {

                Buscar.OficioBuscarIdCommand command = new()
                {
                    OficioId = id
                };

                OficioDto OficioDtos = await _mediator.Send(command);

                response.Mensaje = "Oficio elimiminada correctamenta";
                response.Entidad = OficioDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new OficioDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<Response<List<OficioDto>>>> Buscar(Buscar.OficioBuscarCommand command)
        {
            Response<List<OficioDto>> response = new();
            try
            {

                List<OficioDto> OficioDtos = await _mediator.Send(command);

                response.Mensaje = "";
                response.Entidad = OficioDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<OficioDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }
    }
}
