using AdoptionPortal.Models;

namespace AdoptionPortal.Services
{
    public class AdoptionService
    {
        private readonly List<Animal> animals = [];

        public void AddAnimal(Animal animal) => animals.Add(animal);

        public Animal GetAnimal(int id) =>
                animals.Single(a => a.Id == id);
        public IEnumerable<Animal> GetAvailableAnimals() =>
            animals.Where(a => !a.IsAdopted);

        public bool AdoptAnimal(Adopter adopter, int animalId)
        {
            var animal = animals.FirstOrDefault(a => a.Id == animalId && !a.IsAdopted);
            if (animal == null) return false;

            animal.MarkAsAdopted();
            adopter.Adopt(animal);
            return true;
        }

        public bool IsAnimalAvailable(int id) =>
            animals.Any(a => a.Id == id && !a.IsAdopted);


    }
}
