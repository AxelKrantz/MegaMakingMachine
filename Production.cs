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
        readonly Material[][] productRequirements = new Material[3][];
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
        public void ProduceGoods()
        {
            //TODO - Here we need to loop through our item-arrays and insert the items needed for producing an item.
            int requiredSteel = 1; //dessa behöver ändras baserat på antalet av varje sort som krävs. 
            int requiredRubber = 1;
            //foreach (Material.rubber item in productRequirements[0])
            //{

            //
                if (ProvidedRubber.Count >= requiredRubber && ProvidedSteel.Count >= requiredSteel) 
                {
                    //Console.WriteLine($"You made a {productRequirements[i][0]}");
                    Console.WriteLine($"You made a wheel");
                    ProductsToStorage.Add(Material.wheel);
                for (int i = 0; i < requiredRubber; i++)
                {
                    ProvidedRubber.RemoveAt(0);
                }
                for (int i = 0; i < requiredSteel; i++)
                {
                    ProvidedSteel.RemoveAt(0);
                }
                    System.Threading.Thread.Sleep(2500);
                }
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
