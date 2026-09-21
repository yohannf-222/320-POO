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
        private int _x { get; }
        private int _y { get; }

        public Charger(int x, int y)
        {
            this._x = x;
            this._y = y;           
        }


        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);
       
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.Charger, Convert.ToSingle(_x) - 10, Convert.ToSingle(_y) - 10, 20, 20);            
        }

    }
}
