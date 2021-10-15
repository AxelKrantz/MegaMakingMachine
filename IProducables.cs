using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMakingMachine
{
    interface IProducables
    {
        abstract string Name { get;}
        IList<Material> RequiredComponents {get; }
    }
}
