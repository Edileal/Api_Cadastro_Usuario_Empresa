using CadastroUsuarioEmpresa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Repository.Mappings
{
    public class EmpresaEntitiesMap
    {
        public void Configure(EntityTypeBuilder<EmpresaEntities> builder)
        {
            builder.HasOne(prop => prop.Endereco).WithOne();
        }
    }
}
