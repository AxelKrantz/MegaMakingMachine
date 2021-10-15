using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMakingMachine
{
    abstract class Blueprint
    {
        string name;
        int complexity;
        List<Material> requiredItems;
    }
}
