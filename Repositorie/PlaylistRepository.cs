using maxVideo1.Data;
using maxVideo1.Interfaces;
using maxVideo1.Model;
using Microsoft.EntityFrameworkCore;

namespace maxVideo1.Repositorie
{
    public class PlaylistRepository(ApplicationDbContext dbContext) : IPlaylistRepository
    {
        private readonly ApplicationDbContext _dbcontext = dbContext;


        public async Task<List<PlaylistModel>> GetPlaylists()
        {
            return await _dbcontext.Playlists.ToListAsync();
        }


        public async Task<List<PlaylistModel>> GetAllPlaylist()
        {
            return await _dbcontext.Playlists.ToListAsync();
        }


        public async Task<PlaylistModel> GetPlaylistById(int id)
        {
            return await _dbcontext.Playlists.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Playlist com ID: {id} não encontrada");
        }


        public async Task<PlaylistModel> AddPlaylist(PlaylistModel playlist)
        {
            await _dbcontext.Playlists.AddAsync(playlist);
            await _dbcontext.SaveChangesAsync();
            return playlist;
        }



        public async Task<PlaylistModel> UpdatePlaylist(PlaylistModel playlist, int id)
        {
            PlaylistModel playlistPorId = await GetPlaylistById(id) ?? throw new Exception($"Playlist por ID: {id} não encontrada");
            playlistPorId.Name = playlist.Name;
            playlistPorId.User = playlist.User;
            return playlistPorId;
        }


        public async Task<bool> DeletePlaylist(int id)
        {
            PlaylistModel playlistPorId = await GetPlaylistById(id) ?? throw new Exception($"Playlist por ID: {id} não encontrada");
            _dbcontext.Playlists.Remove(playlistPorId);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

    }
}
