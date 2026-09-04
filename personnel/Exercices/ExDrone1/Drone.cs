using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ExDrone1
{
    public class Drone
    {
        public int _battery;
        private int _posX;
        private int _posY;
        private string _drone;
        private string _deadDrone;
        public string _droneState;

        public Drone(int battery, int posX, int posY, string drone)
        {
            this._battery = battery;
            this._posX = posX;
            this._posY = posY;
            this._drone = drone;
            this._deadDrone = "_____";
        }

        public Drone()
        {
            this._battery = 50;
            this._posX = 0;
            this._posY = 2;
            this._drone = "x-O-x";
            this._deadDrone = "_____";
        }

        public void drawDrone()
        {
            Console.SetCursorPosition(this._posX, this._posY);

            if (GetDroneState(_battery) == "normal")
            {
                Console.Write(_drone);
                Console.SetCursorPosition(this._posX, this._posY - 1);
                Console.Write(this._battery + "%");
            }
            else if (GetDroneState(_battery) == "exploded")
            {
                Console.Write("XXXX");
                Console.SetCursorPosition(this._posX, this._posY - 1);
                Console.WriteLine("Blew up for techncal reasons");
            }
            else
            {
                Console.Write(_deadDrone);
                Console.SetCursorPosition(this._posX, this._posY - 1);
                Console.WriteLine("battery empty");
            }
        }

        public void changeDroneState()
        {
            if (this._battery <= 0) return;

            this._battery = this._battery - 2;
            this._posX++;
        }

        string GetDroneState(int battery)
        {
            if (_battery <= 0) return "empty";

            Random random = new Random();
            int randomNumber = random.Next(1, 10);
            if (randomNumber == 1)
            {
                return "exploded";
            }
            return "normal";
        }
    }
}
