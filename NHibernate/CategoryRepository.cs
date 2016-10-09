using monei.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.NHibernate
{
    public class CategoryRepository
    {
        public IEnumerable<Category> List()
        {
            IEnumerable<Category> categories = new List<Category>();
            
            return categories;
        }
    }
}
