using EjemploPosgres.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;

namespace EjemploPosgres.Modelos.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Persona> Personas { get; set; }
        
    }
}
