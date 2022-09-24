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
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar el registro: " + ex.Message);
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al borrar el registro: " + ex.Message);
            }
        }


        public void Update(T entity)
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
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el registro: " + ex.Message);
            }
        }
    }
}
