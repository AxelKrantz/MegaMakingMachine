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
        readonly List<Material> materialsForProduction = new(), itemsReservedForProduct = new();
        readonly List<Blueprints> blueprints = new();
        public List<Material> productsToStorage = new();
        readonly Wheel wheel = new();
        readonly Car car = new();
        readonly Nothing nothing = new();
        Blueprints _choosenBlueprint;
        public Production()
        {
            blueprints.Add(car);
            blueprints.Add(wheel);
        }
        public void GetMaterial(List<Material> materialsToFactory)
        {
            materialsForProduction.AddRange(materialsToFactory);
        }
        public void CheckMaterialRequirements()
        {
            bool stillCheckingRequirements = true;
            while (stillCheckingRequirements)
            {

                for (int i1 = 0; i1 < blueprints.Count; i1++)
                {

                    var choosenBlueprint = blueprints[i1];

                    for (int y = 0; y < choosenBlueprint.RequiredMaterial.Count; y++)
                    {

                        for (int i = materialsForProduction.Count - 1; i >= 0; i--)
                        {

                            if (choosenBlueprint.RequiredMaterial[y] == materialsForProduction[i])
                            {
                                itemsReservedForProduct.Add(materialsForProduction[i]);
                                materialsForProduction.RemoveAt(i);
                                break;
                            }
                        }

                    }
                    if (itemsReservedForProduct.Count == choosenBlueprint.RequiredMaterial.Count)
                    {
                        _choosenBlueprint = choosenBlueprint;
                        Console.WriteLine($"Name of choosenBlueprint was: {choosenBlueprint.Name}");
                        System.Threading.Thread.Sleep(1000);
                        stillCheckingRequirements = false;
                        break;
                    }
                    else
                    {

                        _choosenBlueprint = null;
                        materialsForProduction.AddRange(itemsReservedForProduct);
                        itemsReservedForProduct.Clear();
                        if (i1 == blueprints.Count-1)
                        {
                            Console.WriteLine("Could not find any suitable blueprints.");
                            System.Threading.Thread.Sleep(2000);
                            _choosenBlueprint = nothing;
                            stillCheckingRequirements = false;
                        }
                    }
                }
            }
        }
        public void ProduceGoods()
        {
            var choosenBlueprint = _choosenBlueprint;
            if (choosenBlueprint.RequiredMaterial.Count == itemsReservedForProduct.Count && _choosenBlueprint.Name != "nothing")
            {
                Console.WriteLine($"You made a {choosenBlueprint.Name}");
                productsToStorage.Add((Material)Enum.Parse(typeof(Material), choosenBlueprint.Name));
                itemsReservedForProduct.Clear();
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine("Returning items to storage");
                System.Threading.Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine($"You made {_choosenBlueprint.Name}");
                System.Threading.Thread.Sleep(1500);
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
