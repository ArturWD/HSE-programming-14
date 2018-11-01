using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsLib
{
    public class Collections<T>
    {
        public List<T> zoo { get; set; }
        public List<T> birdSection { get; set; }
        public Collections()
        {
            zoo = new List<T>();
            birdSection = new List<T>(0);
        }
    }
}
