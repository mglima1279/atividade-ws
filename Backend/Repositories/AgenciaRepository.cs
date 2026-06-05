using Backend.Data;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class AgenciaRepository
    {
        private readonly AppDbContext _context;

        public AgenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Agencia> Save(Agencia entity)
        {
            entity.Id = 0;
            _context.Agencias.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Agencia> Save(int id, Agencia entity)
        {
            Agencia existingEntity = await FindById(id);

            Agencia dbAgencia = await FindById(entity.Id) ?? throw new Exception("404 - Not Found");

            dbAgencia.Name = (entity.Name != "") ? entity.Name : dbAgencia.Name;
            dbAgencia.City = (entity.City != "") ? entity.City : dbAgencia.City;
            dbAgencia.State = (entity.State != "") ? entity.State : dbAgencia.State;

            _context.Agencias.Update(existingEntity);

            await _context.SaveChangesAsync();
            return existingEntity;
        }

        public async Task<Agencia> FindById(int id)
        {
            return await _context.Agencias.FindAsync(id) ?? throw new Exception($"404 -  {id} NOT FOUND.");
        }

        public async Task<List<Agencia>> FindAll()
        {
            return await _context.Agencias.ToListAsync();
        }

        public async Task Delete(int id)
        {
            Agencia? entity = await _context.Agencias.FindAsync(id);
            if (entity != null)
            {
                _context.Agencias.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
