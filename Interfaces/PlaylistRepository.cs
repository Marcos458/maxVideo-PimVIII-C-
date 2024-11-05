using maxVideo1.Model;

namespace maxVideo1.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<List<PlaylistModel>> GetAllPlaylist();
        Task<PlaylistModel> GetPlaylistById(int id);
        Task<PlaylistModel> AddPlaylist(PlaylistModel playlist);
        Task<PlaylistModel> UpdatePlaylist(PlaylistModel playlist, int id);
        Task<bool> DeletePlaylist(int id);

    }
}
