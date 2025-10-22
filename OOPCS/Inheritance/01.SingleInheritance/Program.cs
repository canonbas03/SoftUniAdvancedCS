using _01.SingleInheritance;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var dog = new Dog();
            dog.Bark();

            var puppy = new Puppy();
            puppy.Bark();
            puppy.Eat();
            puppy.Weep();
        }
    }
}
