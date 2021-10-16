using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMakingMachine
{
    class Blueprints
    {
        public List<Material> _requiredMaterials = new();
        public string _name;
    }
    class Car : Blueprints
    {
        public string name;
        public List<Material> requiredMaterial = new() { Material.steel, Material.steel, Material.wheel, Material.wheel, Material.wheel, Material.wheel };
        public Car()
        {
           name = "car";
        }
    }
    class Wheel : Blueprints
    {
        public string name;
        public List<Material> requiredMaterial = new() {Material.rubber, Material.steel };
        public Wheel()
        {
            name = "wheel";
        }
    }
    // Make it possible to add classes with a method?
}
