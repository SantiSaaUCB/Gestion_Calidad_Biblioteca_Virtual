using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Biblioteca_Virtual.Context;
using Biblioteca_Virtual.Entities;
using Biblioteca_Virtual.Services.Usuario;

namespace Biblioteca_Virtual
{
    public class CreateModel : PageModel
    {
        private readonly IUsuarioService _service;

        public CreateModel(IUsuarioService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.Crear(Usuario);
            return RedirectToPage("./Index");
        }
    }
}
