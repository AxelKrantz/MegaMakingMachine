﻿using System;
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
        List<Blueprints> blueprints = new();
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
                        Console.WriteLine("DEBUGG still checking requirements turned false");
                        _choosenBlueprint = choosenBlueprint;
                        System.Threading.Thread.Sleep(2000);
                        stillCheckingRequirements = false;
                        break;
                    }
                    else
                    {
                        _choosenBlueprint = null;
                        Console.WriteLine("DEBUGG ItemsReservedForProduct was not same length as choosenBlueprint.RequireMaterial");
                        materialsForProduction.AddRange(itemsReservedForProduct);
                        itemsReservedForProduct.Clear();
                        System.Threading.Thread.Sleep(2000);
                    }
                    
                }
            }
        }
        public void ProduceGoods()
        {
            var choosenBlueprint = _choosenBlueprint;
            Console.WriteLine($"Name of choosenBlueprint was: {choosenBlueprint.Name}");
            System.Threading.Thread.Sleep(2000);
            if (choosenBlueprint.RequiredMaterial.Count == itemsReservedForProduct.Count && choosenBlueprint.Name != null)
            {
                Console.WriteLine($"You made a {choosenBlueprint.Name}");
                productsToStorage.Add((Material)Enum.Parse(typeof(Material), choosenBlueprint.Name));
                //TODO return leftover materials to storage.
                System.Threading.Thread.Sleep(2500);
                Console.WriteLine("Returning items to storage");
                System.Threading.Thread.Sleep(2500);
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
