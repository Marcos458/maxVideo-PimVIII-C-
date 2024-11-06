using maxVideo1.Data;
using maxVideo1.Interfaces;
using maxVideo1.Model;
using maxVideo1.Repositorie;
using Microsoft.AspNetCore.Mvc;


namespace maxVideo1.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ConteudoController(IConteudoRepository conteudoRepository) : ControllerBase
    {
        private readonly IConteudoRepository _conteudoRepository = conteudoRepository;

        [HttpGet("{id}")]
        public async Task<ConteudoModel> GetConteudoByIdAsync(int id)
        {
            return await _conteudoRepository.GetConteudoById(id);
        }


        [HttpGet]
        public async Task<IEnumerable<ConteudoModel>> GetConteudoModelsAsync()
        {
            return await _conteudoRepository.GetConteudosAsync();
        }


        [HttpPost("upload")]
        public async Task<ActionResult<ConteudoModel>> AddConteudoAsync(IFormFile videoFile, [FromForm] ConteudoModel conteudo)
        {

            try { var createdConteudo = await _conteudoRepository.AddConteudoAsync(conteudo, videoFile); 
                return CreatedAtAction(nameof(GetConteudoByIdAsync), new { id = createdConteudo.Id }, createdConteudo);
            } 
            
            catch (ArgumentException ex) 

            { 
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task UpdateConteudoAsync(ConteudoModel conteudo)
        {
            await _conteudoRepository.UpdateConteudoAsync(conteudo);
            return;
        }


        [HttpDelete("{id}")]
        public async Task DeleteConteudoAsync(int id)
        { 
            await _conteudoRepository.DeleteConteudoAsync(id);
            
        }
    }
}
