using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Production converts materials to products and makes sure we dont try to produce things we dont have enough items for.
namespace MegaMakingMachine
{
    class Production
    {
        List<Material> MaterialsForProduction = new();
        public List<Material> ProductsToStorage = new();
        private List<Material> ProvidedRubber { get; set; } = new();
        private List<Material> ProvidedSteel { get; set; } = new();
        private List<Material> ProvidedWheel { get; set; } = new();
        public Production()
        {

        }
        //Sorts the items from storage into lists which only hold one type of item each. 
        public void GetMaterial(List<Material> materialsToFactory)
        {
            MaterialsForProduction = materialsToFactory;
            ProvidedRubber.AddRange(MaterialsForProduction.FindAll(x => x.Equals(Material.rubber)));
            ProvidedSteel.AddRange(MaterialsForProduction.FindAll(x => x.Equals(Material.steel)));
        }
        //TODO Sort blueprints by count
        //public void SortBlueprints()
        //{
        //    var sortedBlueprints = _blueprints.OrderByDescending(x => x.complexity);
        //}

        //TODO Check blueprints in order if all components are present in mater
        public void ProduceGoods()
        {
            Car bilen = new Car();
            Wheel hjulet = new Wheel();
            var choosenBlueprint = hjulet;
            int[] taggedItems = new int[10];
            for (int i = 0; i < choosenBlueprint.requiredMaterial.Count; i++)
            {
                if (choosenBlueprint.requiredMaterial.ElementAt(i) )
                {

                }
            }
            for (int i = 0; i < bilen.requiredMaterial.Count; i++)
            {
                MaterialsForProduction.Remove(bilen.requiredMaterial.ElementAt(i));
                Console.WriteLine(bilen.requiredMaterial.ElementAt(i));
            }
                Console.WriteLine($"You made a {new Wheel()}");
                ProductsToStorage.Add(Material.wheel);
                for (int i = 0; i < 3; i++)
                {
                    ProvidedRubber.RemoveAt(0);
                }
                for (int i = 0; i < 3; i++)
                {
                    ProvidedSteel.RemoveAt(0);
                }
                System.Threading.Thread.Sleep(2500);
                Console.WriteLine("Returning items to storage");
                System.Threading.Thread.Sleep(2500);
        }
        public List<Material> SendProductsToStorage()
        {
            ProductsToStorage.AddRange(ProvidedRubber);
            ProductsToStorage.AddRange(ProvidedSteel);
            ProvidedRubber.Clear();
            ProvidedSteel.Clear();
            return ProductsToStorage;
        }
    }
}
