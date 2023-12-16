using GrooveGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrooveGallery.Services.Memory
{
    public class AlbumService : IAlbumService
    {
        private IList<Album> _albums;

        public AlbumService()
        {
            CarregarListaInicial();
        }

        private void CarregarListaInicial()
        {
            _albums = new List<Album>()
            {
                new Album
                {
                    AlbumId = 1,
                    Nome = "Álbum 1",
                    Artista = "Artista 1",
                    Descricao = "Descrição do Álbum 1",
                    ImagemUri = "/images/album1.jpg",
                    Preco = 19.99,
                    EntregaExpressa = true,
                    Duracao = new TimeSpan(0, 45, 30),
                    DataLancamento = new DateTime(2022, 1, 15),
                    DataCadastro = DateTime.Now,
                    MarcaId = 1,
                    Categorias = new List<Categoria>
                    {
                        new Categoria { CategoriaId = 1, Descricao = "Rock" },
                        new Categoria { CategoriaId = 2, Descricao = "Alternativo" }
                    }
                },
                new Album
                {
                    AlbumId = 2,
                    Nome = "Álbum 2",
                    Artista = "Artista 2",
                    Descricao = "Descrição do Álbum 2",
                    ImagemUri = "/images/album2.jpg",
                    Preco = 24.99,
                    EntregaExpressa = false,
                    Duracao = new TimeSpan(1, 10, 15),
                    DataLancamento = new DateTime(2022, 3, 20),
                    DataCadastro = DateTime.Now,
                    MarcaId = 2,
                    Categorias = new List<Categoria>
                    {
                        new Categoria { CategoriaId = 3, Descricao = "Pop" },
                        new Categoria { CategoriaId = 4, Descricao = "Indie" }
                    }
                },
            };
        }

        public IList<Album> ObterTodos()
        {
            return _albums;
        }

        public Album Obter(int id)
        {
            return _albums.SingleOrDefault(item => item.AlbumId == id);
        }

        public void Incluir(Album album)
        {
            var proximoNumero = _albums.Max(item => item.AlbumId) + 1;
            album.AlbumId = proximoNumero;
            _albums.Add(album);
        }

        public void Alterar(Album album)
        {
            var albumEncontrado = Obter(album.AlbumId);
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
        }

        public void Excluir(int id)
        {
            var albumEncontrado = Obter(id);
            _albums.Remove(albumEncontrado);
        }

        public IList<Marca> ObterTodasAsMarcas()
        {
            return new List<Marca>()
            {
                new Marca() { MarcaId = 1, Descricao = "Marca 1" },
                new Marca() { MarcaId = 2, Descricao = "Marca 2" },
            };
        }

        public IList<Categoria> ObterTodasAsCategorias()
        {
            return new List<Categoria>()
            {
                new Categoria() { CategoriaId = 1, Descricao = "Categoria 1" },
                new Categoria() { CategoriaId = 2, Descricao = "Categoria 2" },
            };
        }
    }
}
