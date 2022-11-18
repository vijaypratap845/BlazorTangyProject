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
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CategoryRepo(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            this.mapper = _mapper;
        }
        public CategoryDTO Create(CategoryDTO objDTO)
        {
            var category = mapper.Map<CategoryDTO, Category>(objDTO);
            var addCategory = dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            return mapper.Map<Category, CategoryDTO>(addCategory.Entity);
        }

        public int Delete(int id)
        {
            var obj = dbContext.Categories.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                dbContext.Categories.Remove(obj);
                return dbContext.SaveChanges();
            }
            return 0;
        }

        public CategoryDTO Get(int id)
        {
            var obj = dbContext.Categories.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                return mapper.Map<Category, CategoryDTO>(obj);

            }
            return null;
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(dbContext.Categories);
        }

        public CategoryDTO Update(CategoryDTO objDTO)
        {
            var obj = dbContext.Categories.FirstOrDefault(u=>u.Id==objDTO.Id);
            if (obj != null)
            {
                obj.Name = objDTO.Name;
                dbContext.Categories.Update(obj);
                dbContext.SaveChanges();
                return mapper.Map<Category, CategoryDTO>(obj);
            }
            return objDTO;
        }
    }
}
