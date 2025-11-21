using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {className}");

            Type classType = Type.GetType(className);

            FieldInfo[] fields = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Public |
                BindingFlags.NonPublic | BindingFlags.Static);

            var searchedFields = fields
                .Where(f => fieldNames.Contains(f.Name))
                .ToList();

            Object classInstance = Activator.CreateInstance(classType);

            foreach (FieldInfo field in searchedFields)
            {
                var value = field.GetValue(classInstance);
                sb.AppendLine($"{field.Name} = {value}");
            }

            return sb.ToString();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);

            FieldInfo[] fieldInfos = classType.GetFields();

            foreach (FieldInfo field in fieldInfos)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            PropertyInfo[] properties = classType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (PropertyInfo property in properties)
            {
                MethodInfo getMethod = property.GetGetMethod(true);

                if (getMethod != null && !getMethod.IsPublic)
                {
                    sb.AppendLine($"{getMethod.Name} have to be public!");
                }

                MethodInfo setMethod = property.GetSetMethod(true);

                if (setMethod != null && !setMethod.IsPrivate)
                {
                    sb.AppendLine($"{setMethod.Name} have to be private!");
                }
            }

            return sb.ToString();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            var allPrivMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in allPrivMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString();
        }
    }
}
