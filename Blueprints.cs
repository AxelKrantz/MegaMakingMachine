using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMakingMachine
{
    abstract class Blueprints
    {
        public List<Material> RequiredMaterial { get; set; }
        public string Name { get; set; }
    }
    class Car : Blueprints
    {
        public new string Name
        {
            get { return Name; }
            init { Name = "car"; }
        }
        //public List<Material> RequiredMaterial :{ Material.steel, Material.steel, Material.wheel, Material.wheel, Material.wheel, Material.wheel };
        public Car()
        {
            
            RequiredMaterial = new List<Material> { Material.steel, Material.steel };
        }

    }


    class Wheel : Blueprints
    {
        public string Name
        {
            get { return Name; }
            init { }
        }
        //public List<Material> RequiredMaterial = new() { Material.rubber, Material.steel };
        public Wheel()
        {
            Name = "wheel";
            RequiredMaterial = new List<Material> { Material.steel, Material.rubber };
        }
    }
    // Make it possible to add classes with a method?
}
