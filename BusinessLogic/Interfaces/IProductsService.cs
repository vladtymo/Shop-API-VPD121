using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        void Create(Product product);
        void Edit(Product product);
        void Delete(int id);

    }
}
