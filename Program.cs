using System;
using MegaMakingMachine;
using System.Collections.Generic;

Factory stoneridge = new();
while (true)
{
    stoneridge.ShowStorage();
    stoneridge.SendMaterialToProduction();
    stoneridge.ClearInventoryList();
    stoneridge.ProduceGoods();
    stoneridge.SendProductToStorage();
}
//Should materials be contained to only raw materials or should finished products also be a type of material.
//Or should we say that products contain a variable of the type material?
//If the name for each product exists as an enum, then we can keep that in the materials list and every item that has a blueprint refers to the enum-name.
//We might be contaminating our data flow a bit with mixing products and raw-materials but... it might be the best way in this instance