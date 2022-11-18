using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangy_Models.BlazorModels
{
    public class DemoProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public List<Categories> Categories { get; set; }
    }
    public class Categories
    {
        public string CategoryName { get; set; }
    }
}
