using CadastroUsuarioEmpresa.Domain.Entities;
using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly CadastroUsuarioEmpresaContext _context;

        public EnderecoRepository(CadastroUsuarioEmpresaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EnderecoEntities>> Get()
        {
            return await _context.Enderecos.AsNoTracking().ToListAsync();
        }

        public async Task<EnderecoEntities> GetById(int id)
        {
            return await _context.Enderecos.Where(prop => prop.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<EnderecoEntities> Post(EnderecoEntities request)
        {
            await _context.Enderecos.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<EnderecoEntities> Put(EnderecoEntities request, int? id = null)
        {
            _context.Enderecos.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task Delete(EnderecoEntities request)
        {
            _context.Enderecos.Remove(request);
            await _context.SaveChangesAsync();
        }
        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }

        
    }
}
