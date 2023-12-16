using System.ComponentModel.DataAnnotations;

namespace GrooveGallery.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Nome do Álbum' obrigatório.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Campo 'Nome do Álbum' deve conter entre 10 e 50 caracteres.")]
        public string Nome { get; set; }

        public string NomeSlug => Nome?.ToLower().Replace(" ", "-");

        [Display(Name = "Artista")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Artista' obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo 'Artista' deve conter entre 5 e 50 caracteres.")]
        public string Artista { get; set; }

        [Display(Name = "Descrição")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Descrição' obrigatório.")]
        [StringLength(100, MinimumLength = 50, ErrorMessage = "Campo 'Descrição' deve conter entre 50 e 100 caracteres.")]
        public string Descricao { get; set; }

        [Display(Name = "Caminho da Imagem")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Caminho da Imagem' obrigatório.")]
        public string ImagemUri { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Campo 'Preço' obrigatório.")]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }

        [Display(Name = "Entrega Expressa")]
        public bool EntregaExpressa { get; set; }

        public string EntregaExpressaFormatada => EntregaExpressa ? "Sim" : "Não";

        [Display(Name = "Duração do Álbum")]
        [Required(ErrorMessage = "Campo 'Duração do Álbum' obrigatório.")]
        [DataType(DataType.Time)]
        public TimeSpan Duracao { get; set; }

        [Display(Name = "Lançamento")]
        [Required(ErrorMessage = "Campo 'Lançamento' obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Disponível em")]
        [Required(ErrorMessage = "Campo 'Disponível em' obrigatório.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM \\de yyyy}")]
        public DateTime DataCadastro { get; set; }


        [Display(Name = "Marca")]
        public int? MarcaId { get; set; }


        public ICollection<Categoria>? Categorias { get; set; }
    }
}
