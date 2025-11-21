namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            // string result = spy.StealFieldInfo("Hacker", "username","password");
            // string result = spy.AnalyzeAccessModifiers("Hacker");
            // string result = spy.RevealPrivateMethods("Hacker");
            string result = spy.CollectGetteraAndSetters("Hacker");
            Console.WriteLine(result);
        }
    }
}
