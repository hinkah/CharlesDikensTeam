using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    

    public class Program
    {
        public static void MovingBoundarys(MovableObject obj)
        {
            if (obj.TopLeft.Col == 0)
            {
                obj.Speed = new MatrixCoords(0, 1);
            }
            if (obj.TopLeft.Col == 94)
            {
                obj.Speed = new MatrixCoords(0, -1);
            } 
            if (obj.TopLeft.Row == 0)
            {
                obj.Speed = new MatrixCoords(1, 0);
            }
            if (obj.TopLeft.Row == 28)
            {
                obj.Speed = new MatrixCoords(-1, 0);
            }
        }
        static void Main(string[] args)
        {
            //ss
            char[,] shit = new char[,] {{'(', '\\', '_', '_','_',  '/', ')'},
                                       {'(', '=', '\'', '.', '\'', '=', ')'},
                                       {'(', '"', ')', '_', '(', '"', ')'}};
            
            
            char[,] shit2 = new char[,] {{'(', '\'', '_', '_', '\'', ')'},
                                       {'R', 'A', 'B','B', 'I', 'T'}};
            char[,] shit3 = new char[,] {{'(', '\'', '_', '_', '\'', ')'},
                                       {'T', 'U', 'R','T', 'L', 'E'}};
                                       
            Engine engine = new Engine(new ConsoleRenderer(30, 110, 0), new KeyboardInterface());
            engine.AddMovingObject(new Rabbit(new MatrixCoords(0, 20), shit, new MatrixCoords(1, 0)));
            engine.AddMovingObject(new SuperHero(new MatrixCoords(10, 26), shit2, new MatrixCoords(0, 0), 0, 0));
            engine.AddMovingObject(new Turtle(new MatrixCoords(25, 10), shit3, new MatrixCoords(0, -1)));
            engine.Run(100);
          
        }
    }
}
