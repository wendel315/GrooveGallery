using GrooveGallery.Models;
using System.Collections.Generic;

namespace GrooveGallery.Services
{
    public interface IAlbumService
    {
        IList<Album> ObterTodos();
        Album Obter(int id);
        void Incluir(Album album);
        void Alterar(Album album);
        void Excluir(int id);
        IList<Marca> ObterTodasAsMarcas();
        IList<Categoria> ObterTodasAsCategorias();
    }
}
