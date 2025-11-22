using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter _interpreter;
        public Engine(ICommandInterpreter interpreter)
        {
            _interpreter = interpreter;
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                string result = _interpreter.Read(input);

                Console.WriteLine(result);
            }
        }
    }
}
