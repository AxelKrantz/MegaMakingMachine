using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Production converts materials to products and makes sure we dont try to produce things we dont have enough items for.
namespace MultiplicatoryMegaMakingMachine
{
    class Production
    {
        Material[][] productRequirements = new Material[3][];

       
        List<Material> MaterialsForProduction = new();
        public List<Material> ProductsToStorage = new();
        private List<Material> ProvidedRubber { get; set; } = new();
        private List<Material> ProvidedSteel { get; set; } = new();
        private List<Material> ProvidedWheel { get; set; } = new();

        public Production()
        {
            //Filling out our two dimensional array with items.
            //The First item in each array is what we want to produce, the others are the materials required for that item.
            productRequirements[0][0] = Material.toaster;
            productRequirements[0][1] = Material.steel;
            productRequirements[0][2] = Material.steel;
            productRequirements[1][0] = Material.wheel;
            productRequirements[1][1] = Material.steel;
            productRequirements[1][2] = Material.rubber;
            productRequirements[2][0] = Material.car;
            productRequirements[2][1] = Material.wheel;
            productRequirements[2][2] = Material.wheel;
            productRequirements[2][3] = Material.wheel;
            productRequirements[2][4] = Material.wheel;
            productRequirements[2][5] = Material.steel;
            productRequirements[2][6] = Material.steel;
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
            //Här behöver vi loopa igenom våra arrays och lägga in de saker som vi behöver för att producera det 
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
