using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMakingMachine
{
    interface ICreateableItems
    {
        public List<Material> RequiredMaterial { get; set; }
        public string Name { get; set; }
    }
    class Car : ICreateableItems
    {
        public string Name { get; set; }
        public List<Material> RequiredMaterial { get; set; }
        public Car()
        {
            Name = "car";
            RequiredMaterial = new List<Material> { Material.steel, Material.steel, Material.wheel, Material.wheel, Material.wheel, Material.wheel };
        }
    }
    class Wheel : ICreateableItems
    {
        public string Name { get; set; }
        public List<Material> RequiredMaterial { get; set; }
        public Wheel()
        {
            Name = "wheel";
            RequiredMaterial = new List<Material> { Material.steel, Material.rubber };
        }
    }
    class Toaster : ICreateableItems
    {
        public string Name { get; set; }
        public List<Material> RequiredMaterial { get; set; }
        public Toaster()
        {
            Name = "toaster";
            RequiredMaterial = new List<Material> { Material.steel, Material.steel };
        }
    }
    class Rubberboots : ICreateableItems
    {
        public string Name { get; set; }
        public List<Material> RequiredMaterial { get; set; }
        public Rubberboots()
        {
            Name = "rubberboots";
            RequiredMaterial = new List<Material> { Material.rubber, Material.rubber };
        }
    }
    class Steeltipped : ICreateableItems
    {
        public string Name { get; set; }
        public List<Material> RequiredMaterial { get; set; }
        public Steeltipped()
        {
            Name = "steeltippedrubberboots";
            RequiredMaterial = new List<Material> { Material.rubberboots, Material.steel };
        }
    }
    class Placeholder : ICreateableItems
    {
        public string Name { get; set; }
        public List<Material> RequiredMaterial { get; set; }
        public Placeholder(string name, List<Material> requiredMaterial)
        {
            Name = name;
            RequiredMaterial = requiredMaterial;
        }
        public Placeholder()
        {
        }
    }
    class Nothing : ICreateableItems //special case to deal with the issue when no blueprint fits the input materials 
    {
        public string Name { get; set; }
        public List<Material> RequiredMaterial { get; set; }
        public Nothing()
        {
            Name = "nothing";
            RequiredMaterial = new List<Material> { };
        }
    }
    // Make it possible to add classes with a method?
}
