using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public class Program
    {       
        
        static void Main(string[] args)
        {
            Engine engine = new Engine(new ConsoleRenderer(30, 110, 0), new KeyboardInterface());
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
