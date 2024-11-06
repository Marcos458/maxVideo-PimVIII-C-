using maxVideo1.Model;



namespace maxVideo1.Interfaces
{
    public interface IConteudoRepository
    {
        Task<ConteudoModel> GetConteudoById(int Id);
        Task<IEnumerable<ConteudoModel>> GetConteudosAsync();
        Task <ConteudoModel> AddConteudoAsync(ConteudoModel conteudo, IFormFile videoFile);
        Task <ConteudoModel>UpdateConteudoAsync(ConteudoModel conteudo);
        Task <ConteudoModel>DeleteConteudoAsync(int id);
        
    }
}
