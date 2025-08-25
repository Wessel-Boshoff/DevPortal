using AdoptionPortal.Models;
using AdoptionPortal.Services;

var adoptionService = new AdoptionService();

// Seed animals
adoptionService.AddAnimal(new Dog { Id = 1, Name = "Buddy", Age = 3, Breed = "Chihuahua", IsTrained = true });
adoptionService.AddAnimal(new Cat { Id = 2, Name = "Whiskers", Age = 2, Breed = "Scottish Fold", LivesRemaining = 8 });
adoptionService.AddAnimal(new Dog { Id = 3, Name = "Max", Age = 5, Breed = "Poodle", IsTrained = false });

var adopter = new Adopter { Id = 1, FirstNames = "John", LastName = "Doe" };

var adoptSystem = new AdoptSystem(adoptionService, adopter);
adoptSystem.Run();

public class AdoptSystem
{
    private readonly AdoptionService adoptionService;
    private readonly Adopter adopter;

    public AdoptSystem(AdoptionService adoptionService, Adopter adopter)
    {
        this.adoptionService = adoptionService;
        this.adopter = adopter;
    }

    public void Run()
    {
        Console.Clear();
        Console.WriteLine(" Available animals:");
        foreach (var animal in adoptionService.GetAvailableAnimals())
        {
            Console.WriteLine($"{animal.Id}: {animal.Name} ({animal.GetType().Name}), " +
                              $"Age {animal.Age}, Says {animal.Speak()}");
        }

        Console.Write("\nSelect animal by ID: ");
        if (!int.TryParse(Console.ReadLine(), out int selected))
        {
            Console.WriteLine(" Invalid selection. Press a key to try again...");
            Console.ReadKey();
            Run();
            return;
        }

        if (!adoptionService.IsAnimalAvailable(selected))
        {
            Console.WriteLine(" Invalid selection. Press a key to try again...");
            Console.ReadKey();
            Run();
            return;
        }

        var selectedAnimal = adoptionService.GetAnimal(selected);
        if (selectedAnimal == null)
        {
            Console.WriteLine(" Animal not found. Press a key to try again...");
            Console.ReadKey();
            Run();
            return;
        }

        var success = adoptionService.AdoptAnimal(adopter, selectedAnimal.Id);

        if (success)
        {
            Console.WriteLine($"\n {adopter.FirstNames} {adopter.LastName} successfully adopted {selectedAnimal.Name}!");
        }
        else
        {
            Console.WriteLine("\n Adoption failed. Press a key to try again...");
            Console.ReadKey();
            Run();
            return;
        }

        Console.WriteLine("\nRemaining available animals:");
        foreach (var animal in adoptionService.GetAvailableAnimals())
        {
            Console.WriteLine($"{animal.Id}: {animal.Name} ({animal.GetType().Name}), Age {animal.Age}");
        }

        Console.WriteLine($"\n{adopter.FirstNames}'s adopted animals:");
        foreach (var pet in adopter.AdoptedAnimals)
        {
            Console.WriteLine($"{pet.Name} ({pet.GetType().Name}), Age {pet.Age}");
        }

        Console.WriteLine("\nPress any key to adopt again...");
        Console.ReadKey();
        Run();
    }
}
