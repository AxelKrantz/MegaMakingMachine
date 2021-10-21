using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Materials contains materials. Logically.
namespace MegaMakingMachine
{
    abstract class Material
    {
        public MaterialType _typeOfMaterial;
        public virtual string Name { get; set; }
    }
    class Rubber : Material
    {
        
        public Rubber()
        {
            _typeOfMaterial = MaterialType.Rubber;
            Name = "rubber";
        }
    }
    class Metal : Material
    {

    }
    class Steel : Metal
    {

        public Steel()
        {
            _typeOfMaterial = MaterialType.Metal;
            Name = "steel";
        }
    }
    class Iron : Metal
    {
        public Iron()
        {
            Name = "iron";
            _typeOfMaterial = MaterialType.Metal;
        }
    }
    class UserCreated : Material
    {
        public UserCreated(string name)
        {
            Name = name;
        }
    }
}
