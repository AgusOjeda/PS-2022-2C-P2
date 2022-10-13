using Application.Interfaces;
using Domain.Interfaces;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Command
{
    public class CommandHandler<T> : ICommandHandler<T> where T : IEntity
    {
        private readonly AppDbContext _context;

        public CommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            try
            {
                _context.Add(entity);
                Console.WriteLine("Inserting entity");
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar el registro: " + ex.Message);
            }
        }

        public async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al borrar el registro: " + ex.Message);
            }
        }


        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            try
            {
                _context.ChangeTracker.Clear();
                _context.Entry(entity).State = EntityState.Detached;
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el registro: " + ex.Message);
            }
        }
    }
}
