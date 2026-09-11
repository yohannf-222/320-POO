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
        private int _battery;
        private int _posX;
        private int _posY;
        private string _drone;
        private string _deadDrone;

        public int Battery { get => _battery; }

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
            if (this.Battery > 0)
            {
                Console.Write(_drone);
                Console.SetCursorPosition(this._posX, this._posY - 1);
                Console.Write(this.Battery + "%");
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
            if (this.Battery <= 0) return;

            this._battery = this._battery - 2;
            this._posX++;
        }
    }
}
