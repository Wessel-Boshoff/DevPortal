using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptionPortal.Models
{
    public class Adopter : Person
    {
        public List<Animal> AdoptedAnimals { get; } = [];

        public void Adopt(Animal animal)
        {
            AdoptedAnimals.Add(animal);
        }
    }
}
