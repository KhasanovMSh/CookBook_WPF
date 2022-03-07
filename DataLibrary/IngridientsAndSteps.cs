using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class IngridientsAndSteps
    {
        private string _ingridients;
        private string _steps;

        public string Ingridients
        {
            get => _ingridients;
            set => _ingridients = value;
        }

        public string Steps
        {
            get => _steps;
            set => _steps = value;
        }
    }
}
