using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var allTypes = typeof(Tracker).Assembly.GetTypes();

            foreach (var type in allTypes)
            {
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

                foreach (var method in methods)
                {
                    var authorAttribute = method
                       .GetCustomAttributes<AuthorAttribute>()
                       .Select(attr => attr.Name)
                       .ToList();

                    if (authorAttribute.Count > 0)
                    {
                        Console.WriteLine($"{method.Name} is written by {string.Join(", ", authorAttribute)}");
                    }
                }

            }
        }
    }
}
