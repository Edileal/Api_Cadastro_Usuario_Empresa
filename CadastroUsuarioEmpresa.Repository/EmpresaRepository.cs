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
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly CadastroUsuarioEmpresaContext _context;
        public EmpresaRepository(CadastroUsuarioEmpresaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmpresaEntities>> Get()
        {
            return await _context.Empresas.AsNoTracking().ToListAsync();
        }

        public async Task<EmpresaEntities> GetById(int id)
        {
            return await _context.Empresas.Where(prop => prop.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<EmpresaEntities> Post(EmpresaEntities request)
        {
            await _context.Empresas.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<EmpresaEntities> Put(EmpresaEntities request, int? id =null)
        {
            _context.Empresas.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task Delete(EmpresaEntities request)
        {
            _context.Empresas.Remove(request);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }
    }
}
