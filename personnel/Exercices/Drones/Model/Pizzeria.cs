using Drones.Helpers;
using Drones.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            this.Name = name;
        }


        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);

        public int X
        {
            get => _x;
            set
            {
                if (value >= Config.AIRSPACE_WIDTH - Config.PIZZERIA_SIDE_LENGTH / 2)
                    _x = Config.AIRSPACE_WIDTH - Config.PIZZERIA_SIDE_LENGTH / 2;
                else if (value <= Config.PIZZERIA_SIDE_LENGTH / 2)
                    _x = Config.PIZZERIA_SIDE_LENGTH / 2;
                else
                    _x = value;
            }
        }
        public int Y
        {
            get => _y;
            set
            {
                if (value >= Config.AIRSPACE_HEIGHT - Config.PIZZERIA_SIDE_LENGTH / 2)
                    _y = Config.AIRSPACE_HEIGHT - Config.PIZZERIA_SIDE_LENGTH / 2;
                else if (value <= Config.PIZZERIA_SIDE_LENGTH / 2)
                    _y = Config.PIZZERIA_SIDE_LENGTH / 2;
                else
                    _y = value;
            }
        }
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
                pizzerias.Add(new Pizzeria(RndValueHelpers.alea.Next(Config.PIZZERIA_SIDE_LENGTH / 2, Config.AIRSPACE_WIDTH - Config.PIZZERIA_SIDE_LENGTH / 2), RndValueHelpers.alea.Next(Config.PIZZERIA_SIDE_LENGTH / 2, Config.AIRSPACE_HEIGHT - Config.PIZZERIA_SIDE_LENGTH / 2), $"Pizzeria{i}"));
            }
            return pizzerias;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.Pizzeria, Convert.ToSingle(X) - Config.PIZZERIA_SIDE_LENGTH / 2, Convert.ToSingle(Y) - Config.PIZZERIA_SIDE_LENGTH / 2, Config.PIZZERIA_SIDE_LENGTH, Config.PIZZERIA_SIDE_LENGTH);
            drawingSpace.Graphics.DrawString($"{this.Name}", TextHelpers.drawFont, TextHelpers.writingBrush, Convert.ToSingle(_x + 10), Convert.ToSingle(_y - Config.PIZZERIA_SIDE_LENGTH / 2));
        }

    }
}
