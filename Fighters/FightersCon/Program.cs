using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    class Program
    {
        static void Main(string[] args)
        {
            //ss
            char[,] shit = new char[,] {{'(', '\\', '_', '_','_',  '/', ')'},
                                       {'(', '=', '\'', '.', '\'', '=', ')'},
                                       {'(', '"', ')', '_', '(', '"', ')'}};
            
            
            char[,] shit2 = new char[,] {{'(', '\'', '_', '_', '\'', ')'},
                                       {'R', 'A', 'B','B', 'I', 'T'}};
                                       
            Engine engine = new Engine(new ConsoleRenderer(30, 110, 0), new KeyboardInterface());
            engine.AddMovingObject(new Rabbit(new MatrixCoords(0, 0), shit, new MatrixCoords(1, 1)));
            engine.AddMovingObject(new SuperHero(new MatrixCoords(0, 10), shit2, new MatrixCoords(0, 0), 0, 0));
            engine.Run(500);
           
        }
    }
}
