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
        List<ICreateableItems> blueprints = new() { new Car(), new Wheel(), new Toaster() };
        public List<Material> productsToStorage = new();
        readonly Placeholder placeholder = new();
        readonly Nothing nothing = new();
        ICreateableItems _choosenBlueprint;
        public void GetMaterial(List<Material> materialsToFactory)
        {
            materialsForProduction.AddRange(materialsToFactory);
        }
        public void AddBlueprint(ICreateableItems input)
        {
            blueprints.Add(input);
        }
        public void BlueprintSort()
        {
            blueprints = blueprints.OrderByDescending(blueprints => blueprints.RequiredMaterial.Count).ToList();
        }
        public void CheckMaterialRequirements() //Checks through our list of blueprints
        {
            bool stillCheckingRequirements = true;
            while (stillCheckingRequirements)
            {
                for (int j = 0; j < blueprints.Count; j++)
                {
                    var choosenBlueprint = blueprints[j];
                    for (int y = 0; y < choosenBlueprint.RequiredMaterial.Count; y++)
                    {
                        for (int i = materialsForProduction.Count - 1; i >= 0; i--)
                        {
                            var temp = choosenBlueprint.RequiredMaterial[y].GetType();
                            if (choosenBlueprint.RequiredMaterial[y]._typeOfMaterial == materialsForProduction[i]._typeOfMaterial)
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
                        Console.WriteLine($"Blueprint matching materials: {choosenBlueprint.Name}");
                        stillCheckingRequirements = false;
                        break;
                    }
                    else
                    {
                        _choosenBlueprint = null;
                        materialsForProduction.AddRange(itemsReservedForProduct);
                        itemsReservedForProduct.Clear();
                        if (j == blueprints.Count - 1)
                        {
                            Console.WriteLine("Could not find any suitable blueprints.");
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

                Console.WriteLine($"You made a {ReturnMaterialOfType(itemsReservedForProduct)} {choosenBlueprint.Name}");
                
            }
            else
            {
                Console.WriteLine($"You made {_choosenBlueprint.Name}");
                System.Threading.Thread.Sleep(1500);
            }
            StorageHandler(choosenBlueprint);
        }
        public string ReturnMaterialOfType(List<Material> input)
        {
            foreach (Material item in input)
            {
                if (item._typeOfMaterial == MaterialType.Metal)
                {
                    return item.Name;
                }
            }
            return "";
        }
        public void StorageHandler(ICreateableItems choosenBlueprint)
        {
            try
            {
                productsToStorage.Add((Material)choosenBlueprint);
                itemsReservedForProduct.Clear();
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine("Returning items to storage");
            }
            catch (Exception)
            {
                Console.WriteLine($"We dont have any room in the storage for a {choosenBlueprint.Name} so I guess you have to take it with you.");
                itemsReservedForProduct.Clear();
            }
            finally
            {
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine("press any key to continue");
                Console.ReadKey(true);
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