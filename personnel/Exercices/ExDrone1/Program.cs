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
            Console.CursorVisible = false;

            List<Drone> fleet = new List<Drone>{
                new Drone(),
                new Drone(60, 3, 4, "0=x=0"),
                new Drone(40, 10, 6, "X-0-X"),
                new Drone(45, 0, 8, "X--X"),
                new Drone(20, 21, 10, "O-A-O"),
                new Drone(55, 5, 12, ">-0-<")
            };


            while (isOneDroneAlive(fleet))
            {
                Console.Clear();
                foreach (Drone d in fleet)
                {
                    d.changeDroneState();
                    d.drawDrone();
                }
                Thread.Sleep(100);
            }
            Console.Read();
        }

        static bool isOneDroneAlive(List<Drone> drones)
        {
            foreach (Drone d in drones)
            {
                if (d.Battery > 0) return true;
            }
            return false;
        }
    }
}
