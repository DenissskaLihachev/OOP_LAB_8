using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10.Interface2
{
    internal interface IArcher : IRole
    {
        new public int Damage { get; }
    }
}
