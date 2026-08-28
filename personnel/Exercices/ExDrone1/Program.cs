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

            do
            {
                Console.Clear();
                drawDrone(drone, deadDrone, deathMessage, battery, posX, posY);

                changeDroneState(ref battery, ref posX, ref posY);

                Thread.Sleep(150);
                
            } while (battery >= 0);            
            Console.Read();

        }

        static void drawDrone(string drone, string deadDrone, string deathMessage, double battery, int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            if (battery >= 2)
            {
                Console.Write(drone);
                Console.SetCursorPosition(posX, posY - 1);
                Console.Write(battery + "%");
            }

            else
            {
                Console.Write(deadDrone);
                Console.SetCursorPosition(posX, posY - 1);
                Console.WriteLine(deathMessage);
            }

        }

        static void changeDroneState(ref double battery, ref int posX, ref int posY)
        {
            posX++;
            battery = battery - 2;
        }
    }
}
