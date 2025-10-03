using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biblioteca_Virtual.Context;
using Biblioteca_Virtual.Entities;
using Biblioteca_Virtual.Repository;
using Biblioteca_Virtual.Services.Usuario;

namespace Biblioteca_Virtual.Pages.Usuario
{
    public class IndexModel : PageModel
    {
        private readonly IUsuarioService _service;

        public IndexModel(IUsuarioService service)
        {
            _service = service;
        }

        public IList<Entities.Usuario> Usuario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Usuario = await _service.ObtenerTodos();
        }
    }
}
