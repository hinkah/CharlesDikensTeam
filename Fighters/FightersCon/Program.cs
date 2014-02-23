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
            //ss
            char[,] shit = new char[,] {{'(', '\\', '_', '_','_',  '/', ')'},
                                       {'(', '=', '\'', '.', '\'', '=', ')'},
                                       {'(', '"', ')', '_', '(', '"', ')'}};
            
            
            char[,] shit2 = new char[,] {{'(', '\'', '_', '_', '\'', ')'},
                                       {' ', 'H', 'E','R', 'O', ' '}};
            char[,] shit3 = new char[,] {{' ', ' ', '/', '~', '\\', ' '},
                                         {' ', 'C', ' ','o', 'o', ' '},
                                         {' ', '_', '(',' ', '^', ')'},
                                         {'/', ' ', ' ',' ', '~', '\\'}};
                                       
            Engine engine = new Engine(new ConsoleRenderer(30, 110, 0), new KeyboardInterface());
            engine.AddMovingObject(new Rabbit(new MatrixCoords(0, 20), shit, new MatrixCoords(1, 0)));
            engine.AddMovingObject(new SuperHero(new MatrixCoords(10, 26), shit3, new MatrixCoords(0, 0), 0, 0));
            engine.AddMovingObject(new Turtle(new MatrixCoords(25, 10), shit3, new MatrixCoords(0, -1)));
            engine.Run(100);
          
        }
    }
}
