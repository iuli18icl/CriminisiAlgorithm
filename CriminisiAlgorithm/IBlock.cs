using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminisiAlgorithm
{
    internal interface IBlock
    {
        Point TopLeft { get; set; }
        Size Size { get; set; }
    }
}
