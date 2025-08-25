namespace AdoptionPortal.Models
{
    public class Dog : Animal
    {
        public bool IsTrained { get; set; }
        public override string Speak()
        {
            return "Woof";
        }
    }
}
