using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matas_Lukšys_darbo_užduotis
{
    public class Maistas
    {
        public void Dejimas()
        {
            string patiekalas = this.GetType().Name;
            Console.WriteLine($"{patiekalas} dedamas(a) i lekste");
        }
    }
}
