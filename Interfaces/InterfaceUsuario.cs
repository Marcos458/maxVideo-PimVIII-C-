using maxVideo1.Model;

namespace maxVideo1.Interfaces
{

        public interface IUsuarioRepository
        {
            Task<List<UsuarioModel>> GetAllUser();
            Task<UsuarioModel> GetUserById(int id);
            Task<UsuarioModel> AddUser(UsuarioModel user);
            Task<UsuarioModel> UpdateUser(UsuarioModel user, int id);
            Task<bool> DeleteUser(UsuarioModel user, int id);
        }



}

