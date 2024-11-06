using maxVideo1.Data;
using maxVideo1.Interfaces;
using maxVideo1.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace maxVideo1.Repositorie
{
    public class ConteudoRepository(ApplicationDbContext dbContext) : IConteudoRepository
    {
        
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IEnumerable<ConteudoModel>> GetConteudosAsync()
        {
           return await _dbContext.Conteudos.ToListAsync();
        }


        public async Task<ConteudoModel> GetConteudoById(int Id)
        {
            return await _dbContext.Conteudos.FirstOrDefaultAsync(x => x.Id == Id) ?? throw new Exception($"Playlist com ID: {Id} não encontrada");
        }


        public async Task<ConteudoModel> AddConteudoAsync(ConteudoModel conteudo, IFormFile videoFile)
        {

            if (videoFile == null || videoFile.Length == 0 || !Path.GetExtension(videoFile.FileName).Equals(".mp4", StringComparison.CurrentCultureIgnoreCase)) 
            { 
                throw new ArgumentException("Arquivo inválido. Por favor, envie um vídeo no formato MP4.");
            }

            // Define o caminho onde o arquivo será salvo
            var videoPath = Path.Combine("Uploads", videoFile.FileName); 

            // Cria o diretório se não existir
            if (!Directory.Exists("Uploads")) 
            { 
                Directory.CreateDirectory("Uploads"); 
            }

            // Salva o arquivo no sistema de arquivos
            using (var stream = new FileStream(videoPath, FileMode.Create)) 
            {
                await videoFile.CopyToAsync(stream); 
            } 
            // Adiciona o caminho do vídeo ao modelo de conteúdo
            conteudo.VideoPath = videoPath;

            await _dbContext.AddAsync(conteudo);
            await _dbContext.SaveChangesAsync();
            return conteudo;
        }

        public async Task<ConteudoModel> UpdateConteudoAsync(ConteudoModel conteudo)
        {
            ConteudoModel ConteudoPorId = await GetConteudoById(conteudo.Id) ?? throw new Exception($"Conteudo por ID:{conteudo.Id} não Encontrado");
            ConteudoPorId.Titulo = conteudo.Titulo;
            ConteudoPorId.Conteudo = conteudo.Conteudo;
            _dbContext.Update(ConteudoPorId);
            await _dbContext.SaveChangesAsync();
            return ConteudoPorId;
        }

        

        public async Task<ConteudoModel> DeleteConteudoAsync( int id)
        {
            ConteudoModel ConteudoPorId = await GetConteudoById(id) ?? throw new Exception($"Conteudo por ID: {id} não encontrado");
            _dbContext.Remove(ConteudoPorId);
            await _dbContext.SaveChangesAsync();
            return ConteudoPorId;
        }
      
    }
}
