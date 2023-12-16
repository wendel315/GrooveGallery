using GrooveGallery.Data;
using GrooveGallery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrooveGallery.Services.Data
{
    public class AlbumService : IAlbumService
    {
        private readonly GrooveGalleryDbContext _context;

        public AlbumService(GrooveGalleryDbContext context)
        {
            _context = context;
        }

        public void Alterar(Album album)
        {
            var albumEncontrado = Obter(album.AlbumId);

            if (albumEncontrado != null)
            {
                albumEncontrado.Nome = album.Nome;
                albumEncontrado.Artista = album.Artista;
                albumEncontrado.Descricao = album.Descricao;
                albumEncontrado.ImagemUri = album.ImagemUri;
                albumEncontrado.Preco = album.Preco;
                albumEncontrado.EntregaExpressa = album.EntregaExpressa;
                albumEncontrado.Duracao = album.Duracao;
                albumEncontrado.DataLancamento = album.DataLancamento;
                albumEncontrado.DataCadastro = album.DataCadastro;
                albumEncontrado.MarcaId = album.MarcaId;
                albumEncontrado.Categorias = album.Categorias;

                _context.SaveChanges();
            }
            // Considere tratar a situação quando o álbum não é encontrado.
        }

        public void Excluir(int id)
        {
            var albumEncontrado = Obter(id);

            if (albumEncontrado != null)
            {
                _context.Album.Remove(albumEncontrado);
                _context.SaveChanges();
            }
            // Considere tratar a situação quando o álbum não é encontrado.
        }

        public void Incluir(Album album)
        {
            _context.Album.Add(album);
            _context.SaveChanges();
        }

        public Album Obter(int id)
        {
            return _context.Album
                           .Include(item => item.Categorias)
                           .SingleOrDefault(item => item.AlbumId == id);
        }

        public IList<Categoria> ObterTodasAsCategorias()
        {
            return _context.Categoria.ToList();
        }

        public IList<Marca> ObterTodasAsMarcas()
        {
            return _context.Marca.ToList();
        }

        public IList<Album> ObterTodos()
        {
            return _context.Album.ToList();
        }
    }
}
