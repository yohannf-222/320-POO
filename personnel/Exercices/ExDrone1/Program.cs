using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExDrone1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string drone = "x-O-x";
            string deadDrone = "_____";
            string deathMessage = "battery low";
            double battery = 50;
            int posX = 0;
            int posY = 5;

            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(posX, posY);

            while (battery > 0)
            {
                drawDrone(drone, battery, posX, posY);

                changeState(ref battery, ref posX, ref posY);

                Thread.Sleep(150);
                Console.Clear();
            }
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(deadDrone);
            Console.SetCursorPosition(posX, posY - 1);
            Console.WriteLine(deathMessage);
            Console.ReadLine();

        }

        static void drawDrone(string drone, double battery, int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(drone);

            Console.SetCursorPosition(posX, posY - 1);
            Console.Write(battery + "%");

        }

        static void changeState(ref double battery, ref int posX, ref int posY)
        {
            posX++;
            battery = battery - 2;
        }
    }
}
