using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleUnitTest.CodigoATestar.Domain.Entities;

namespace SimpleUnitTest.CodigoATestar.Domain.Contracts
{
    public interface IRepository<T>
    {
        T GetById(int id);

        void Create(T product);
        
        int  GetSequence();
    }
}
