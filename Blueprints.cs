using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMakingMachine
{
    abstract class Blueprints
    {
        //public string name = "Blueprint - If you see this in production something has gone wrong";
        //public List<Material> requiredMaterial;
    }
    class Car : Blueprints
    {
        public string name;
        public new List<Material> requiredMaterial = new() { Material.steel, Material.steel, Material.wheel, Material.wheel, Material.wheel, Material.wheel };
        public Car()
        {
           name = "Car";
        }
    }
    class Wheel : Blueprints
    {
        public string name;
        public new List<Material> requiredMaterial = new() { Material.rubber, Material.steel };
        public Wheel()
        {
            name = "Wheel";
        }
    }
    // Make it possible to add classes with a method?
}
