using GrooveGallery.Models;
using GrooveGallery.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GrooveGallery.Pages
{
   
    public class CreateModel : PageModel
    {
        private IAlbumService _service;
        public SelectList MarcaOptionItems { get; set; }
        public SelectList CategoriaOptionItems { get; set; }

        public CreateModel(IAlbumService albumService)
        {
            _service = albumService;
        }

        public void OnGet()
        {
            MarcaOptionItems = new SelectList(_service.ObterTodasAsMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Descricao));

            CategoriaOptionItems = new SelectList(_service.ObterTodasAsCategorias(),
                                                nameof(Categoria.CategoriaId),
                                                nameof(Categoria.Descricao));
        }


        [BindProperty]
        public Album Album { get; set; }

        [BindProperty]
        public IList<int> CategoriaIds { get; set; }

        public IActionResult OnPost()
        {
            Album.Categorias = _service.ObterTodasAsCategorias()
                                            .Where(item => CategoriaIds.Contains(item.CategoriaId))
                                            .ToList();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Incluir(Album);

            return RedirectToPage("/Index");
        }
    }
}
