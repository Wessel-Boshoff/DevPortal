namespace AdoptionPortal.Models
{
    public class Animal : Entity
    {
        public string? Name { get; set; }
        public string? Breed { get; set; }
        public int Age { get; set; }
        public bool IsAdopted { get; private set; }
        public void MarkAsAdopted() => IsAdopted = true;
        public virtual string Speak() => "";
    }
}
