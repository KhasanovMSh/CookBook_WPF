using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class RecipeCategories
    {
        private List<string> _categories;

        public List<string> Categories
        {
            get => _categories;
            set => _categories = value;
        }
    }
}
