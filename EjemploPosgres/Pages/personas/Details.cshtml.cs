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
    public class DetailsModel : PageModel
    {
        private readonly EjemploPosgres.Modelos.Contexto.Contexto _context;

        public DetailsModel(EjemploPosgres.Modelos.Contexto.Contexto context)
        {
            _context = context;
        }

        public Persona Persona { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FirstOrDefaultAsync(m => m.PersonaId == id);

            if (persona is not null)
            {
                Persona = persona;

                return Page();
            }

            return NotFound();
        }
    }
}
