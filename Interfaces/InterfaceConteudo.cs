using maxVideo1.Model;

namespace maxVideo1.Interfaces
{
    public interface INterfaceConteudo
    {
        Task<ConteudoModel> GetConteudoById(int Id);
        Task<IEnumerable<ConteudoModel>> GetConteudosAsync();
        Task AddConteudoAsync(ConteudoModel conteudo);
        Task UpdateConteudoAsync(ConteudoModel conteudo);
        Task DeleteConteudoAsync(int id);
        Task SaveChangesAsync();
        
    }
}
