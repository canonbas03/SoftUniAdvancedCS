using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models.Interfaces;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            bool isValidNumber = number.All(c => char.IsDigit(c));
            if (!isValidNumber)
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {number}";
        }
        public string Browse(string url)
        {
            bool isValidURL = url.All(c => !char.IsDigit(c));
            if (!isValidURL)
            {
                throw new ArgumentException("Invalid URL!");
            }    

            return $"Browsing: {url}!";
        }

        
    }
}
