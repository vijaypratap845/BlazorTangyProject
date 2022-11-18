using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    public interface IProductRepo
    {
        public ProductDTO Create(ProductDTO objDTO);
        public ProductDTO Update(ProductDTO objDTO);
        public int Delete(int id);
        public ProductDTO Get(int id);
        public IEnumerable<ProductDTO> GetAll();
    }
}
