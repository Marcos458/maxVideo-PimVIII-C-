namespace maxVideo1.Model
{
    public class CriadorModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ConteudoModel? Criador { get; set; } // Propriedade de navegação
        public required List<ConteudoModel> Conteudo { get; set; }
    }
}
