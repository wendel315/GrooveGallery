namespace GrooveGallery.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        public ICollection<Album>? Albuns { get; set; }
    }

}
