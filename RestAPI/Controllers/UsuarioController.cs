using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.DTOs.DictadorDto;
using RestAPI.Models.DTOs.ProductoDTO;
using RestAPI.Models.DTOs.UsuarioDTO;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _productoRepository;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository productoRepository, IMapper mapper, ILogger<IUsuarioRepository> logger)

        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "WPF_User,Angular_User")]
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var entities = _mapper.Map<List<UsuarioDto>>(await _productoRepository.GetAllAsync());
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "WPF_User,Angular_User")]
        [HttpGet("name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var entities = await _productoRepository.GetByNameAsync(name);

                if (entities == null || !entities.Any())
                    return NotFound($"No products found with name: {name}");

                var productsDto = _mapper.Map<List<UsuarioDto>>(entities);
                return Ok(productsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "WPF_User,Angular_User")]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = await _productoRepository.GetByIdAsync(id);

                if (entity == null)
                    return NotFound($"No user found with id: {id}");

                var productDto = _mapper.Map<UsuarioDto>(entity);
                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Angular_User")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateUsuarioDto createDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var entity = _mapper.Map<UsuarioEntity>(new CreateUsuarioDto
                {
                    Nombre = createDto.Nombre,
                    Email = createDto.Email

                });
                await _productoRepository.CreateAsync(entity);

                var dto = _mapper.Map<UsuarioDto>(entity);
                //return CreatedAtRoute($"{ControllerContext.ActionDescriptor.ControllerName}_GeProyectoEntity", new { id = entity.Id }, dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error creating data");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Angular_User")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var entity = await _productoRepository.GetAsync(id);
                if (entity == null) return NotFound();

                _mapper.Map(dto, entity);
                await _productoRepository.UpdateAsync(entity);

                return Ok(_mapper.Map<UsuarioDto>(entity));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error updating data");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Angular_User")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entity = await _productoRepository.GetAsync(id);
                if (entity == null) return NotFound();

                await _productoRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error deleting data");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
