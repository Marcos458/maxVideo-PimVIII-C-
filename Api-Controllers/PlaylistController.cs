using maxVideo1.Interfaces;
using maxVideo1.Model;
using maxVideo1.Repositorie;
using Microsoft.AspNetCore.Mvc;

namespace maxVideo1.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController(IPlaylistRepository playlistRepository) : ControllerBase
    {
        private readonly IPlaylistRepository _playlistRepository = playlistRepository;


        [HttpGet]
        public async Task<ActionResult<List<PlaylistModel>>> GetAllPlaylists()
        {
            var playlists = await _playlistRepository.GetAllPlaylist();
            return Ok(playlists);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistModel>> GetPlaylistById(int id)
        {
            var playlist = await _playlistRepository.GetPlaylistById(id);
            if (playlist == null)
            {
                return NotFound($"Playlist com ID: {id} não encontrada.");
            }
            return Ok(playlist);
        }


        [HttpPost]
        public async Task<ActionResult<PlaylistModel>> AddPlaylist(PlaylistModel playlist)
        {
            await playlistRepository.AddPlaylist(playlist);
            return CreatedAtAction(nameof(GetPlaylistById), new { id = playlist.Id }, playlist);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<PlaylistModel>> UpdatePlaylist(int id, PlaylistModel playlist)
        {
            if (id != playlist.Id)
            {
                return BadRequest("ID da URL não corresponde ao ID do corpo da solicitação.");
            }
            await playlistRepository.UpdatePlaylist(playlist, id);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlaylist(int id)
        {
            var success = await playlistRepository.DeletePlaylist(id);
            if (!success)
            {
                return NotFound($"Playlist com ID: {id} não encontrada.");
            }
            return NoContent();
        }



    }
}
