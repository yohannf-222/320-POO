using Drones.Helpers;
using Drones.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Model
{
    public class Charger
    {
        private int _x;
        private int _y;

        public Charger(int x, int y)
        {
            this.X = x;
            this.Y = y;           
        }


        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.Charger, Convert.ToSingle(X) - 10, Convert.ToSingle(Y) - 10, 20, 20);            
        }

    }
}
