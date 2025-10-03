using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biblioteca_Virtual.Context;
using Biblioteca_Virtual.Entities;
using Biblioteca_Virtual.Services.Usuario;

namespace Biblioteca_Virtual
{
    public class DeleteModel : PageModel
    {
        private readonly IUsuarioService _service;

        public DeleteModel(IUsuarioService service)
        {
            _service = service;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _service.ObtenerPorId(id.Value);

            if (usuario is not null)
            {
                Usuario = usuario;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _service.ObtenerPorId(id.Value);
            if (usuario != null)
            {
                _service.Eliminar(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
