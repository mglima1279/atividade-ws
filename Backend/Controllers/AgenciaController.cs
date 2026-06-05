using Backend.Entities;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController, Route("api/agencias")]
    public class AgenciaController : ControllerBase
    {
        private readonly AgenciaRepository _repository;

        public AgenciaController(AgenciaRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Agencia entity)
        {
            entity = await _repository.Save(entity);

            return Created($"/api/agencias/{entity.Id}", entity);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                Agencia entity = await _repository.FindById(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("404"))
                {
                    return NotFound(e.Message);
                }
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.FindAll());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Agencia entity)
        {
            try
            {
                entity = await _repository.Save(id, entity);
                return Ok(entity);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("404"))
                {
                    return NotFound(e.Message);
                }
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
