using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMakingMachine
{
    abstract class Blueprints
    {
        public virtual List<Material> RequiredMaterial { get; set; }
        public virtual string Name { get; set; }
    }
    class Car : Blueprints
    {
        public override string Name { get; set; }
        public override List<Material> RequiredMaterial { get; set; }
        public Car()
        {
            Name = "car";
            RequiredMaterial = new List<Material> { Material.steel, Material.steel, Material.wheel, Material.wheel, Material.wheel, Material.wheel };
        }
    }
    class Wheel : Blueprints
    {
        public override string Name { get; set; }
        public override List<Material> RequiredMaterial { get; set; }
        public Wheel()
        {
            Name = "wheel";
            RequiredMaterial = new List<Material> { Material.steel, Material.rubber };
        }
    }
    class Nothing : Blueprints
    {
        public override string Name { get; set; }
        public override List<Material> RequiredMaterial { get; set; }
        public Nothing()
        {
            Name = "nothing";
            RequiredMaterial = new List<Material> { };
        }
    }
    // Make it possible to add classes with a method?
}
