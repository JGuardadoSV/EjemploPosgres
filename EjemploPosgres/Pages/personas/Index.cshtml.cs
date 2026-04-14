using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EjemploPosgres.Modelos.Contexto;
using EjemploPosgres.Modelos.Entidades;

namespace EjemploPosgres.Pages.personas
{
    public class IndexModel : PageModel
    {
        private readonly EjemploPosgres.Modelos.Contexto.Contexto _context;

        public IndexModel(EjemploPosgres.Modelos.Contexto.Contexto context)
        {
            _context = context;
        }

        public IList<Persona> Persona { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Persona = await _context.Personas.ToListAsync();
        }
    }
}
