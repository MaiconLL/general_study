using SimpleUnitTest.CodigoATestar.Domain.Contracts;
using SimpleUnitTest.CodigoATestar.Domain.DTO;
using SimpleUnitTest.CodigoATestar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUnitTest.CodigoATestar.Application
{
    internal class ProductController
    {
        private readonly IRepository<Product> _repository;
        public ProductController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public void Gravar(Product product)
        {
            var validationResult = Valid(product);
            if (!validationResult.IsValid)
            {
                throw new Domain.Exception.DataInvalidException(string.Join("\n", validationResult.Errors.Select(x => $"{x}")));
            }

            _repository.Create(product);
        }

        public Product Buscar(int id)
        {
            return _repository.GetById(id);
        }

        private ValidationResult Valid(Product product)
        {
            var validationResult = new ValidationResult();
            validationResult.IsValid = true;
            if (product.Price <= 0)
            {
                validationResult.IsValid = false;
                validationResult.Errors.Add("Price has to be greater than 0.");
            }


            return validationResult;
        }
    }
}
