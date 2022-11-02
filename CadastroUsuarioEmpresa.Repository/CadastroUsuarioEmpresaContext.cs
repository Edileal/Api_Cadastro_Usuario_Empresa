using CadastroUsuarioEmpresa.Domain.Entities;
using CadastroUsuarioEmpresa.Repository.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Repository
{
    public class CadastroUsuarioEmpresaContext : DbContext
    {
        public CadastroUsuarioEmpresaContext() { }

        public DbSet<UsuarioEntities> Usuarios { get; set; }
        public DbSet<EmpresaEntities> Empresas { get; set; }
        public DbSet<EnderecoEntities> Enderecos { get; set; }

        public CadastroUsuarioEmpresaContext(DbContextOptions<CadastroUsuarioEmpresaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEntities>(new UsuarioEntitiesMap().Configure);
            modelBuilder.Entity<EmpresaEntities>(new EmpresaEntitiesMap().Configure);
            modelBuilder.Entity<EnderecoEntities>(new EnderecoEntitiesMap().Configure);
        }
    }
}
