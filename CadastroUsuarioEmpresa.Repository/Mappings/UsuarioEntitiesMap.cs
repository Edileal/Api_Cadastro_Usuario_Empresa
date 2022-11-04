using CadastroUsuarioEmpresa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CadastroUsuarioEmpresa.Domain.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Repository.Mappings
{
    public class UsuarioEntitiesMap
    {
        public void Configure(EntityTypeBuilder<UsuarioEntities> builder)
        {
            builder
                .Property(prop => prop.Role)
                .HasConversion(
                    prop => prop.ToString(),
            prop => (RoleEnum)Enum.Parse(typeof(RoleEnum), prop)
                );

            builder.HasIndex(prop => prop.Email).IsUnique();
            builder.HasIndex(prop => prop.Cpf).IsUnique();

            builder.HasOne(prop => prop.Endereco).WithOne();
        }
    }
}
