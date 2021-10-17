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
        public void ShowStorage()
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
        public List<Material> UserPicksMaterial()
        {
            MaterialToFactory.Clear();
            string selection;  
            while (true)
            {
                Console.WriteLine("\nType the material you want to send to production. To start production: type \"produce\"");
                selection = Console.ReadLine().ToLower();
                if (selection == "produce") return MaterialToFactory;
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
                ShowStorage();
            }
        }
        public void GetMaterial(List<Material> productsToStorage)
        {
            for (int i = 0; i < productsToStorage.Count; i++)
            {
                materialInStorage.Add(productsToStorage[i]);
            }
        }
        
    }
}