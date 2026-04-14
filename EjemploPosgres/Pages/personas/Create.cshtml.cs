using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EjemploPosgres.Modelos.Contexto;
using EjemploPosgres.Modelos.Entidades;

namespace EjemploPosgres.Pages.personas
{
    public class CreateModel : PageModel
    {
        private readonly EjemploPosgres.Modelos.Contexto.Contexto _context;

        public CreateModel(EjemploPosgres.Modelos.Contexto.Contexto context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Persona Persona { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Personas.Add(Persona);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
