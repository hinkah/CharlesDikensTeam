using System;
using System.Collections.Generic;

namespace FightersCon
{
    public class Program
    {
        public const int consoleRows = 39;
        public const int consoleCols = 100;
        
        static void Main()
        {
            Console.SetBufferSize(112, 39);
            Console.SetWindowSize(112, 39);

            Engine engine = new Engine(new ConsoleRenderer(consoleRows, consoleCols, 0), new KeyboardInterface());
            try
            {
                engine.Run(100);
            }
            catch (InvalidPowerValueException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }          
        }
    }
}
