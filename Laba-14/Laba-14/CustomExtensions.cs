using AnimalsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_14
{
    public static class CustomExtensions
    {
        public static IEnumerable<Animal> GetBirds(this List<Animal> animals)
        {
            return animals.Where(a => a is Bird);
        }
    }
}
