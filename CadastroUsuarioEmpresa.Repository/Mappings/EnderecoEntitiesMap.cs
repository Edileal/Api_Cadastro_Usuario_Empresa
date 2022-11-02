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
    public class EnderecoEntitiesMap
    {
        public void Configure(EntityTypeBuilder<EnderecoEntities> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
