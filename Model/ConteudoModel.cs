using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace maxVideo1.Model
{
    public class ConteudoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Tipo { get; set; } 
        public required string VideoPath { get; set; }

        public PlaylistModel? Playlist { get; set; }
        public int CriadorId { get; set; } // Chave estrangeira
        public required CriadorModel Conteudo { get; set; } // Propriedade de navegaçao
    }
}
