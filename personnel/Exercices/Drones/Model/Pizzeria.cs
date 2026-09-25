using Drones.Helpers;
using Drones.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Model
{
    public class Pizzeria
    {
        private int _x;
        private int _y;
        private string _name;

        public Pizzeria(int x, int y, string name)
        {
            this.X = x;
            this.Y = y;
            this.Name = Name;
        }


        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public string Name { get => _name; set => _name = value; }


        /// <summary>
        /// Crée une liste de drone de longueur nb, jusqu'à 8
        /// </summary>
        /// <param name="nb"> le nombre de drones dans la liste</param>
        /// <returns></returns>
        public static List<Pizzeria> GeneratePizzerias(int nb)
        {
            if (nb > 10) nb = 10;

            List<Pizzeria> pizzerias = new List<Pizzeria>();

            for (int i = 0; i < nb; i++)
            {
                pizzerias.Add(new Pizzeria(RndValueHelpers.alea.Next(Config.AIRSPACE_WIDTH), RndValueHelpers.alea.Next(Config.AIRSPACE_HEIGHT), $"Pizzeria{i}"));
            }
            return pizzerias;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.Pizzeria, Convert.ToSingle(X) - 10, Convert.ToSingle(Y) - 10, 20, 20);
        }

    }
}
