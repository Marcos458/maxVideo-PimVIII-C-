using maxVideo1.Data;
using maxVideo1.Model;
using Microsoft.EntityFrameworkCore;


namespace maxVideo1.Repositorie
{
    public class UsuarioRepository(ApplicationDbContext dbContext) : Interfaces.IUsuarioRepository
        {
            private readonly ApplicationDbContext _dbcontext = dbContext;


            public async Task<List<UsuarioModel>> GetAllUser()
            {
                return await _dbcontext.Users.ToListAsync();
            }


            public async Task<UsuarioModel> GetUserById(int id)
            {
                return await _dbcontext.Users.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Usuário com ID: {id} não encontrado.");
            }


            public async Task<UsuarioModel> AddUser(UsuarioModel user)
            {

                await _dbcontext.Users.AddAsync(user);
                await _dbcontext.SaveChangesAsync();
                return user;
            }


            public async Task<UsuarioModel> UpdateUser(UsuarioModel user, int id)
            {
            UsuarioModel usuarioPorId = await GetUserById(user.Id) ?? throw new Exception($"Usuario por ID:{id} não Encontrado");
                usuarioPorId.Name = user.Name;
                usuarioPorId.Email = user.Email;
                _dbcontext.Users.Update(usuarioPorId);
                await _dbcontext.SaveChangesAsync();
                return usuarioPorId;
            }


            public async Task<bool> DeleteUser(UsuarioModel user, int id)
            {
            UsuarioModel usuarioPorId = await GetUserById(user.Id) ?? throw new Exception($"Usuario por ID:{id} não Encontrado");
                _dbcontext.Users.Remove(usuarioPorId);
                await _dbcontext.SaveChangesAsync();
                return true;
            }



        }
    }
