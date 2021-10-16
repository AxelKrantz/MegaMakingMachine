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
        List<Material> materialsForProduction = new();
        public List<Material> productsToStorage = new();
        List<Material> itemsReservedForProduct = new();
        Wheel wheel = new();
        Car car = new();
        List<object> blueprints = new();
        public Production()
        {
            List<object> blueprints = new() { car, wheel };
        }
        public void GetMaterial(List<Material> materialsToFactory)
        {
            materialsForProduction.AddRange(materialsToFactory);
        }
        //TODO Sort blueprints by count
        public void CheckMaterialRequirements()
        {
            for (int i1 = 0; i1 < blueprints.Count; i1++)
            {
                var choosenBlueprint = blueprints.ElementAt(i1.);
                for (int y = 0; y < choosenBlueprint.requiredMaterial.Count; y++)
                {
                    for (int i = materialsForProduction.Count - 1; i >= 0; i--)
                    {
                        if (choosenBlueprint.requiredMaterial.ElementAt(y) == materialsForProduction[i])
                        {
                            itemsReservedForProduct.Add(materialsForProduction[i]);
                            materialsForProduction.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }
        public void ProduceGoods()
        {
            var choosenBlueprint = wheel;
            bool readyForProduction = true;
            if (itemsReservedForProduct.Count == choosenBlueprint.requiredMaterial.Count)
            {
                Console.WriteLine($"You made a {choosenBlueprint.name}");
                productsToStorage.Add((Material)Enum.Parse(typeof(Material), choosenBlueprint.name));
                //TODO return leftover materials to storage.
                System.Threading.Thread.Sleep(2500);
                Console.WriteLine("Returning items to storage");
                System.Threading.Thread.Sleep(2500);
            }
            else
            {
                materialsForProduction.AddRange(itemsReservedForProduct);
                itemsReservedForProduct.Clear();
                readyForProduction = false;
            }
        }
        public List<Material> SendProductsToStorage()
        {
            productsToStorage.AddRange(materialsForProduction);
            materialsForProduction.Clear();
            return productsToStorage;
        }
    }
}
