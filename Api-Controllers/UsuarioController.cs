using maxVideo1.Interfaces;
using maxVideo1.Model;
using Microsoft.AspNetCore.Mvc;


namespace maxVideo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController(IUsuarioRepository userRepository) : ControllerBase
    {

            private readonly IUsuarioRepository _userRepository = userRepository;


            [HttpGet("{id}")]
            public async Task<ActionResult<UsuarioModel>> GetUserById(int id)
            {
                var user = await _userRepository.GetUserById(id);
                if (user == null)
                {
                    return NotFound($"Usuário com ID: {id} não encontrado");
                }
                return (user);
            }


    }


    
}
