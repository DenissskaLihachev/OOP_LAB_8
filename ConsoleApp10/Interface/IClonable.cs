using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10.Interface
{
    internal interface IClonable
    {
        object Clone();
        static object Clone(List<IClonable> clonables)
        {
            List<IClonable> clone = new List<IClonable>();
            foreach (IClonable clonable in clonables) clone.Add((IClonable)clonable.Clone());
            return clone;
        }
    }
}
