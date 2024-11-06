using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace maxVideo1.Model
{
    public class UsuarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        public required List<PlaylistModel>? Playlist { get; set; } //Propriedade de navegaçao
    }
}

