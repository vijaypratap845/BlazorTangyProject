using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public ProductRepo(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            this.mapper = _mapper;
        }
        public ProductDTO Create(ProductDTO objDTO)
        {
            var product = mapper.Map<ProductDTO, Product>(objDTO);
            var addProducts = dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return mapper.Map<Product, ProductDTO>(addProducts.Entity);
        }

        public int Delete(int id)
        {
            var obj = dbContext.Products.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                dbContext.Products.Remove(obj);
                return dbContext.SaveChanges();
            }
            return 0;
        }

        public ProductDTO Get(int id)
        {
            var obj = dbContext.Products.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                return mapper.Map<Product, ProductDTO>(obj);

            }
            return null;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(dbContext.Products);
        }

        public ProductDTO Update(ProductDTO objDTO)
        {
            var obj = dbContext.Products.FirstOrDefault(u => u.Id == objDTO.Id);
            if (obj != null)
            {
                obj.Name = objDTO.Name;
                obj.Description = objDTO.Description;
                obj.ImageUrl = objDTO.ImageUrl;
                //obj.CategoryId = objDTO.CategoryId;
                obj.Color = objDTO.Color;
                obj.ShopFavourites = objDTO.ShopFavourites;
                obj.CustomerFavourites = objDTO.CustomerFavourites;
                dbContext.Products.Update(obj);
                dbContext.SaveChanges();
                return mapper.Map<Product, ProductDTO>(obj);
            }
            return objDTO;
        }
    }
}
