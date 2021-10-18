using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Storage handles the storing materials not currently used in production aswell as ways to display it to the user. 
namespace MegaMakingMachine
{
    class Storage
    {
        public bool youHaveChoosenBlueprintCreation = false;
        private readonly List<Material> materialInStorage = new();
        public List<Material> MaterialToFactory { get; set; } = new();
        public Storage() //Storage fills up on creation.  
        {
            int steelInStorage = 6;
            int rubberInStorage = 6;
            for (int i = 0; i < steelInStorage; i++)
            {
                materialInStorage.Add(Material.steel);
            }
            for (int i = 0; i < rubberInStorage; i++)
            {
                materialInStorage.Add(Material.rubber);
            }
        }
        public void ShowStorage() //Shows the items we have in the storage aswell as the items going to the factory
        {
            materialInStorage.Sort();
            Console.Clear();
            Console.WriteLine("These items are currently in storage:");
            foreach (Material item in materialInStorage)
            {
                Console.WriteLine($"-{item}");
            }
            Console.WriteLine("\nThese are the items headed to the factory:");
            foreach (Material item in MaterialToFactory)
            {
                Console.WriteLine($"-{item}");
            }
        }
        public Placeholder CreateBlueprint() //This method is only used if you want to create your own blueprint. 
        {
            if (youHaveChoosenBlueprintCreation)
            {
                youHaveChoosenBlueprintCreation = false;
                Console.WriteLine("Name the item your blueprint will produce");
                string tempName = Console.ReadLine();
                List<Material> tempList = new();
                string selection;
                Console.WriteLine("Input the materials required for your blueprint, to complete the blueprint enter \"finish\"");
                while (true)
                {
                    selection = Console.ReadLine().ToLower();
                    try
                    {
                        var materialChoice = Enum.Parse(typeof(Material), selection);
                        tempList.Add((Material)materialChoice);
                    }
                    catch (Exception)
                    {
                        if (selection == "finish")
                        {
                            Placeholder userMadeBlueprint = new(tempName, tempList);
                            return userMadeBlueprint;
                        }
                        Console.WriteLine("Incorrect Entry, try again.");
                        System.Threading.Thread.Sleep(1500);
                    }
                }
            }
            return null;
        }
        public List<Material> UserPicksMaterial() //The method to let user select one of the enums in material for input. 
        {
            MaterialToFactory.Clear();
            string selection;
            while (true)
            {
                Console.WriteLine("\nType the material you want to send to production. \nTo start production: type \"produce\". \nIf you want to create a blueprint, enter \"blueprint\".");
                selection = Console.ReadLine().ToLower();
                if (selection == "produce") return MaterialToFactory;
                if (selection == "blueprint") { youHaveChoosenBlueprintCreation = true; return MaterialToFactory; }
                try
                {
                    var materialChoice = Enum.Parse(typeof(Material), selection);
                    for (int i = 0; i < materialInStorage.Count; i++)
                    {
                        if ((Material)materialChoice == materialInStorage[i])
                        {
                            MaterialToFactory.Add(materialInStorage[i]);
                            materialInStorage.RemoveAt(i);
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect Entry, try again.");
                    System.Threading.Thread.Sleep(1500);
                }
                ShowStorage();
            }
        }
        public void GetMaterial(List<Material> productsToStorage) //Moves material selected from the storage to the production. 
        {
            for (int i = 0; i < productsToStorage.Count; i++)
            {
                materialInStorage.Add(productsToStorage[i]);
            }
        }
    }
}