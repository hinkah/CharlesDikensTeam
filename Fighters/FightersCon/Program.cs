using System;
using System.Collections.Generic;

namespace FightersCon
{
    public class Program
    {
        public const int consoleRows = 39;
        public const int consoleCols = 100;
        
        static void Main(string[] args)
        {
            Engine engine = new Engine(new ConsoleRenderer(consoleRows, consoleCols, 0), new KeyboardInterface());
            try
            {
                engine.Run(100);
            }
            catch (ArgumentException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }          
        }
    }
}
