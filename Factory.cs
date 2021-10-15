using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//The factory in itself is basically a shell containing instances of all the different areas of the factory as well as methods to move inventory between the different areas of the factory.
namespace MegaMakingMachine
{
    class Factory
    {
        readonly Storage storage = new();
        readonly Material material = new();
        readonly Production production = new();
        readonly Blueprints blueprints = new();

        public void ShowStorage()
        {
            storage.ShowStorage();
        }
        public void UserPicksMaterial()
        {
            storage.UserPicksMaterial();
        }
        public void SendMaterialToProduction()
        {
            production.GetMaterial(storage.UserPicksMaterial());
            production.ProductsToStorage.Clear();
        }
        public void SendProductToStorage()
        {
            storage.GetMaterial(production.SendProductsToStorage());
            production.ProductsToStorage.Clear();
        }
        public void ProduceGoods()
        {
            production.ProduceGoods();
        }
        public void ClearInventoryList()
        {
            storage.MaterialToFactory.Clear();
        }
    }
}
