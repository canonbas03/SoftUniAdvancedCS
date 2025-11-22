using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Utils
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);

                var customValidationAttributes = property.GetCustomAttributes<MyValidationAttribute>();
                foreach (var attribute in customValidationAttributes)
                {
                    if(!attribute.IsValid(value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
