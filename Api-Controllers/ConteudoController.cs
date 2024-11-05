using maxVideo1.Data;
using maxVideo1.Interfaces;
using maxVideo1.Model;
using maxVideo1.Repositorie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace maxVideo1.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ConteudoController(INterfaceConteudo conteudoRepository) : ControllerBase
    {
        private readonly INterfaceConteudo _conteudoRepository = conteudoRepository;


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


        [HttpPost]
        public async Task<ActionResult<ConteudoModel>> AddConteudoAsync(ConteudoModel conteudo)
        {
            await _conteudoRepository.AddConteudoAsync(conteudo);
            await _conteudoRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetConteudoByIdAsync), new { id = conteudo.Id }, conteudo);
        }


        [HttpPut]
        public async Task UpdateConteudoAsync(ConteudoModel conteudo)
        {
            await _conteudoRepository.UpdateConteudoAsync(conteudo);
            await _conteudoRepository.SaveChangesAsync();
        }


        [HttpDelete("{id}")]
        public async Task DeleteConteudoAsync(int id)
        { 
            await _conteudoRepository.DeleteConteudoAsync(id);
            
        }
    }
}
