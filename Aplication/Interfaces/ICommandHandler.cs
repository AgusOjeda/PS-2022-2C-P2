using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommandHandler<T> where T : IEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
