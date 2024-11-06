using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace maxVideo1.Model
{
    public class PlaylistModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }

        public required UsuarioModel User { get; set; } // Propriedade de navegação

        public required List<ConteudoModel> Conteudos { get; set; }

    }
}
