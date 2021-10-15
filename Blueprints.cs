using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMakingMachine
{
    class Blueprints
    {
        public Dictionary<string, int> BlueprintComplexity = new();
        public Blueprints()
        {
            BlueprintComplexity.Add("Wheel", 2);
            BlueprintComplexity.Add("Car", 10);
            var sortedBlueprints = from entry in BlueprintComplexity orderby entry.Value descending select entry;
        }
        public class Wheel : IProducables
        {
            private readonly string _name = "Wheel";
            private readonly List<Material> _requiredComponents = new() { Material.rubber, Material.steel };
            public string Name { get => _name;  }
            public IList<Material> RequiredComponents { get => _requiredComponents; }
        }
        public class Car : IProducables
        {
            private readonly string _name = "Car";
            private readonly List<Material> _requiredComponents = new() { Material.wheel, Material.wheel, Material.wheel, Material.wheel, Material.steel, Material.steel };
            public string Name { get => _name; }
            public IList<Material> RequiredComponents { get => _requiredComponents; }
        }
    }
}
