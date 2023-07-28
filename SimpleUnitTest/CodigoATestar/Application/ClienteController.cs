using SimpleUnitTest.CodigoATestar.Domain.Contracts;
using SimpleUnitTest.CodigoATestar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUnitTest.CodigoATestar.Application
{
    public class ClienteController
    {
        private readonly IRepository<Cliente> _clienteRepository;
        public ClienteController(IRepository<Cliente> repository)
        {
            _clienteRepository = repository;            
        }

        public Cliente BuscarCliente(int id)
        {
            return _clienteRepository.GetById(id);
        }

    }
}
