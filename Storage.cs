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
            int steelInStorage = 8;
            int rubberInStorage = 8;
            int ironInStorage = 5;
            for (int i = 0; i < steelInStorage; i++)
            {
                materialInStorage.Add(new Steel());
            }
            for (int i = 0; i < rubberInStorage; i++)
            {
                materialInStorage.Add(new Rubber());
            }
            for (int i = 0; i < ironInStorage; i++)
            {
                materialInStorage.Add(new Iron());
            }
        }
        public void ShowStorage() //Shows the items we have in the storage aswell as the items going to the factory
        {

            Console.Clear();
            Console.WriteLine("These items are currently in storage:");
            foreach (var item in materialInStorage)
            {
                Console.WriteLine($"-{item.Name}");
            }
            Console.WriteLine("\nThese are the items headed to the factory:");
            foreach (Material item in MaterialToFactory)
            {
                Console.WriteLine($"-{item.Name}");
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
                    int numbersInList = tempList.Count;
                    foreach (Material item in materialInStorage)
                    {
                        if (selection == item.Name)
                        {
                            tempList.Add(item);
                            break;
                        }
                    }
                    if (selection == "finish")
                    {
                        Placeholder userMadeBlueprint = new(tempName, tempList);
                        UserCreated usercreated = new(tempName);
                        return userMadeBlueprint;
                    }
                    else if (numbersInList == tempList.Count)
                    {
                        Console.WriteLine("Incorrect Entry, try again.");
                    }
                    System.Threading.Thread.Sleep(1500);
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
                    for (int i = 0; i < materialInStorage.Count; i++)
                    {
                        if (selection == materialInStorage[i].Name)
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