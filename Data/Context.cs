using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Oficina.Models;
using Microsoft.AspNetCore.Mvc;


namespace Oficina.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Oficina.Models.Ordem> Ordem { get; set; }

    }
}