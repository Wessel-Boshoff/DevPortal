namespace AdoptionPortal.Models
{
    public class Cat : Animal
    {
        public int LivesRemaining { get; set; } = 9;
        public override string Speak()
        {
            return "Meow";
        }
    }
}
